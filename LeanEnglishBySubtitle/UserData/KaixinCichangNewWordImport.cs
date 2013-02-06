using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.UserData
{
    /// <summary>
    /// 开心词场提供生词导出功能，将导出的生词导入到本系统中
    /// </summary>
    class KaixinCichangNewWordImport
    {
        public static IList<string> Parse(string text)
        {
            var lines = text.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            foreach (var line in lines)
            {
                if(line[0]=='#')
                    continue;
                var word = line.Substring(line.IndexOf("  "));
                result.Add(word);
            }
            return result;
        }
    }
}
