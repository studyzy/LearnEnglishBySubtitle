using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Studyzy.LeanEnglishBySubtitle.Helpers
{
    class StringHelper
    {
        private static Regex regex = new Regex("<Q>(.*?)</Q>");
        private static Regex detailRegex = new Regex("<.*?/.*?>");
        public static IList<string> GetCoreDescriptions(string xml)
        {
            var result = new List<string>();
            foreach (Match match in regex.Matches(xml))
            {
                var val = match.Groups[1].Value;

                result.Add(detailRegex.Replace(val, ""));
            }
            return result;
        }
        private static Regex chineseRegex = new Regex("[\u4e00-\u9fa5]");
        public static  bool IsChinese(string str)
        {
            return chineseRegex.IsMatch(str);
        }
    }
}
