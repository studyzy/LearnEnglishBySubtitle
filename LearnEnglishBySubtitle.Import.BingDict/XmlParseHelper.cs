using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LearnEnglishBySubtitle.Import.BingDict
{
    public class XmlParseHelper
    {
        public static IList<string> Parse(string xmlPath)
        {
            var result = new List<string>();
            XmlDocument x = new XmlDocument();
            x.Load(xmlPath);
            XmlNodeList nodes = x.SelectNodes("//Phrases/Phrase");
            foreach (XmlNode y in nodes)
            {
                var word = y.SelectSingleNode("Eng");
                result.Add(word.InnerText);
            }

            return result;
        }
    }
}
