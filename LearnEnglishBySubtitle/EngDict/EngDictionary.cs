using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sun.org.apache.bcel.@internal.generic;

namespace Studyzy.LearnEnglishBySubtitle.EngDict
{
    /// <summary>
    /// 英汉字典，包含对每个英文单词的解释
    /// </summary>
    public class EngDictionary
    {
        public  string Word { get; set; }
        /// <summary>
        /// 音标
        /// </summary>
        public string PhoneticSymbols { get; set; }
        public IList<WordMean> Means { get; set; }
        /// <summary>
        /// 默认的意思
        /// </summary>
        public WordMean DefaultMean { get; set; }
        /// <summary>
        /// XML注释内容
        /// </summary>
        public  string Detail { get; set; }

        public string GetAllMeans()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var mean in Means)
            {
                sb.Append(mean.ToString());
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
  
}
