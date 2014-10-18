using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Studyzy.LearnEnglishBySubtitle.Helpers
{
    class StringHelper
    {
      
        //private static Regex regex2 = new Regex("<N>(.*?)</N>");
        //private static Regex detailRegex = new Regex("<.*?/.*?>");
       
        //public static IList<string> GetCoreDescriptions2(string xml)
        //{
        //    var result = new List<string>();
        //    if (xml.IndexOf("<J D=") > 0)
        //    {
        //        xml = xml.Substring(0, xml.IndexOf("<J D="));
        //        //去掉继承用法和特殊用法的解释
        //    }

        //    foreach (Match match in regex2.Matches(xml))
        //    {
        //        var val = match.Groups[1].Value;

        //        result.Add(detailRegex.Replace(val, ""));
        //    }
        //    return result;
        //}

        private static Regex chineseRegex = new Regex("[\u4e00-\u9fa5]");
        public static  bool IsChinese(string str)
        {
            return chineseRegex.IsMatch(str);
        }
        private static Regex remarkRegex = new Regex(@"\(.*?\)");
        private static Regex remark2Regex = new Regex(@"\{.*?\}");
        public static string RemoveRemark(string line)
        {
            return remarkRegex.Replace(remarkRegex.Replace(line, ""),"");
        }
        public static string RemoveRemark2(string line)
        {
            return remarkRegex.Replace(remark2Regex.Replace(line, ""), "");
        }
    }
}
