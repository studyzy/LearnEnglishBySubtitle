using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Studyzy.LearnEnglishBySubtitle.TranslateServices
{
    class BaiduTranslateService:TranslateService
    {
        public override string TranslateToChinese(string englishSentence)
        {
            string url =
                "http://openapi.baidu.com/public/2.0/bmt/translate?client_id=jiNe8qrbuOznKxZPk0DEHrE4&from=en&to=zh&q=" +
               HttpUtility.UrlEncode( englishSentence);
            string html = GetHtml(url);
            var doc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(html, "baidu-fanyi");
            var txt = doc.SelectSingleNode("baidu-fanyi/trans_result/dst").InnerText;
            return txt;
        }
    }
}
