using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Studyzy.LearnEnglishBySubtitle.TranslateServices
{
    class YoudaoTranslateService:TranslateService
    {
        public override string TranslateToChinese(string englishSentence)
        {
            string url =
               "http://fanyi.youdao.com/openapi.do?keyfrom=EnglishSubtitle&key=247173768&type=data&doctype=text&version=1.0&q=" +
               HttpUtility.UrlEncode(englishSentence);
            string html = GetHtml(url);
          return html.Substring(html.IndexOf("result=") + 7);
        }
    }
}
