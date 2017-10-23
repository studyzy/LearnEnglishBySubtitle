using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Studyzy.LearnEnglishBySubtitle.TranslateServices
{
    class BaiduTranslateService:TranslateService
    {
        public override string TranslateToChinese(string englishSentence)
        {
            string appid = ConfigurationManager.AppSettings["Baidu.AppId"];
            if (string.IsNullOrEmpty(appid))
            {
                appid = "20171023000090334";
            }
            string privKey = ConfigurationManager.AppSettings["Baidu.PrivateKey"];
            if (string.IsNullOrEmpty(privKey))
            {
                privKey = "86OHi2BPw5Zd52a79o3Q";
            }
            var salt = "888";
            var sign = CreateMD5( appid + englishSentence + salt + privKey);
            string url = 
                "http://api.fanyi.baidu.com/api/trans/vip/translate?q=" + HttpUtility.UrlEncode(englishSentence) + "&from=en&to=zh&appid="+appid+"&salt="+salt+"&sign=" +sign
               ;
            string html = GetHtml(url);
            var doc = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseResult>(html);
            var txt = doc.trans_result[0].dst;
            return txt;
        }
        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }

    public class ResponseResult
    {
        public string from { get; set; }
        public string to { get; set; }
        public TransResult[] trans_result { get; set; }
    }

    public class TransResult
    {
        public string src { get; set; }
        public string dst { get; set; }
    }
}
