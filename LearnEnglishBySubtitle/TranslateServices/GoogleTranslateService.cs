using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Studyzy.LearnEnglishBySubtitle.TranslateServices
{
    class GoogleTranslateService:TranslateService
    {
        public override string TranslateToChinese(string englishSentence)
        {
            string stxt = englishSentence.Replace("\r", "").Replace("\n", "");

            string url =
               "http://translate.google.cn/translate_a/single?client=t&sl=en&tl=zh-CN&hl=en&dt=bd&dt=ex&dt=ld&dt=md&dt=qc&dt=rw&dt=rm&dt=ss&dt=t&dt=at&dt=sw&ie=UTF-8&oe=UTF-8&otf=2&rom=1&ssel=3&tsel=4&q=" +
               HttpUtility.UrlEncode(stxt);
            string html = GetHtml(url);
            html = html.Substring(html.IndexOf("\"") + 1);
            var txt = html.Substring(0, html.IndexOf("\",\""));
            return txt;
        }
    }
}
