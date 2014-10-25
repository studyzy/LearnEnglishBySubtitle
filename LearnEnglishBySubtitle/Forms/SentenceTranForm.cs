using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class SentenceTranForm : Form
    {
        public SentenceTranForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url =
                "http://fanyi.youdao.com/openapi.do?keyfrom=EnglishSubtitle&key=247173768&type=data&doctype=text&version=1.0&q=" +
                HttpUtility.UrlEncode(textBox1.Text);
            string html = GetHtml(url);
            textBox2.Text = html.Substring(html.IndexOf("result=") + 7);
        }
        public  String GetHtml(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url =
                "http://openapi.baidu.com/public/2.0/bmt/translate?client_id=jiNe8qrbuOznKxZPk0DEHrE4&from=en&to=zh&q=" +
                textBox1.Text;
            string html = GetHtml(url);
            var doc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(html, "baidu-fanyi");
            var txt = doc.SelectSingleNode("baidu-fanyi/trans_result/dst").InnerText;
            textBox2.Text = txt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdmAccessToken admToken;
            string headerValue;
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx) 
            AdmAuthentication admAuth = new AdmAuthentication("LearnEnglishBySubtitle", "hKBp2IPbGOnpo/lfFlPRvYPSRUb2pRSYMYfmSOauFFc=");
            try
            {
                admToken = admAuth.GetAccessToken();
                // Create a header with the access_token property of the returned token
                headerValue = "Bearer " + admToken.access_token;
                TranslateMethod(headerValue);
            }
            catch (WebException ex)
            {
                ProcessWebException(ex);
                Debug.WriteLine("Press any key to continue...");
             
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                Debug.WriteLine("Press any key to continue...");
             
            }
        }

        private  void TranslateMethod(string authToken)
        {

            string text = textBox1.Text;
            string from = "en";
            string to = "zh";

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
                    //Debug.WriteLine("Translation for source text '{0}' from {1} to {2} is", text, "en", "zh");
                   textBox2.Text=translation;

                }
                Debug.WriteLine("Press any key to continue...");
             
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }
        private  void ProcessWebException(WebException e)
        {
            Debug.WriteLine("{0}", e.ToString());
            // Obtain detailed error information
            string strResponse = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)e.Response)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                    {
                        strResponse = sr.ReadToEnd();
                    }
                }
            }
            Debug.WriteLine("Http status code={0}, error message={1}", e.Status, strResponse);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string url =
                "http://translate.google.cn/translate_a/single?client=t&sl=en&tl=zh-CN&hl=en&dt=bd&dt=ex&dt=ld&dt=md&dt=qc&dt=rw&dt=rm&dt=ss&dt=t&dt=at&dt=sw&ie=UTF-8&oe=UTF-8&otf=2&rom=1&ssel=3&tsel=4&q=" +
                textBox1.Text;
            string html = GetHtml(url);
            html = html.Substring(html.IndexOf("\"") + 1);
            var txt = html.Substring(0, html.IndexOf("\",\""));
            textBox2.Text = txt;
        }
    }

    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }

    public class AdmAuthentication
    {
        public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private string clientId;
        private string cientSecret;
        private string request;

        public AdmAuthentication(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.cientSecret = clientSecret;
            //If clientid or client secret has special characters, encode before sending request
            this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
        }

        public AdmAccessToken GetAccessToken()
        {
            return HttpPost(DatamarketAccessUri, this.request);
        }

        private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
        {
            //Prepare OAuth request 
            WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
    }
}
