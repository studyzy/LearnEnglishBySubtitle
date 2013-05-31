using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearnEnglishBySubtitle.Import.Iciba
{
    public static class CibaTxtParseHelper
    {
        public static IList<string> Parse(string txtPath)
        {
            var list = new List<string>();
            using (StreamReader sr=new StreamReader(txtPath,Encoding.Unicode))
            {
                var txt = sr.ReadToEnd();
                sr.Close();
                foreach (string line in txt.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.StartsWith("+"))//单词行
                    {
                        var word = line.Substring(1);
                        list.Add(word);
                    }
                }
            }
            return list;
        }
    }
}
