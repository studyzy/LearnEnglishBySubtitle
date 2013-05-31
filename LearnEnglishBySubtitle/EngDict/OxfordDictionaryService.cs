using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.EngDict
{
    public class OxfordDictionaryService : DictionaryService
    {
        public override string DictionaryName
        {
            get { return "牛津高阶英汉双解词典"; }
        }

        public override string Ld2FilePath
        {
            get { return "Oxford.ld2"; }
        }
        public override IList<string> GetCoreMeans(string xml)
        {
            var result = new List<string>();
          
            foreach (Match match in regex.Matches(xml))
            {
                var val = match.Groups[1].Value;
                var list = val.Split(new string[] {"<n />"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var mean in list)
                {
                    var m = detailRegex.Replace(mean, ""); //去掉标签
                    if (StringHelper.IsChinese(m))
                    {
                        if (m.IndexOf(":") > 0)
                        {
                            m = m.Substring(0, m.IndexOf(":"));//去掉例句
                            //m = eregex.Replace(m, "");//去掉英文注释
                        }
                        result.Add(m);
                    }
                }

            }
            return result;
        }
        private static Regex detailRegex = new Regex("<.*?/.*?>");
        //牛津词典比较特别，<N>表示大解释，<n />分割其中的小解释
        private static Regex regex = new Regex("<N>(.*?)</N>");
        private static Regex eregex=new Regex("[a-zA-Z]");
    }
}
