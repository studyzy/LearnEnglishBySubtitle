using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Studyzy.LearnEnglishBySubtitle;

namespace LearnEnglishBySubtitle.Import.Youdao
{
    public class XmlParseHelper
    {
        public static IList<string> Parse(string xmlPath)
        {
            var result = new List<string>();
             XmlDocument x = new XmlDocument();
            x.Load(xmlPath);
            XmlNodeList nodes = x.SelectNodes("//item");
            foreach (XmlNode y in nodes)
            {
                var word = y.SelectSingleNode("word");
                result.Add( word.InnerText); 
            }
            
            return result;
        }
    }
}
