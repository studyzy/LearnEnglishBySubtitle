using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public  string Detail { get; set; }
    }
    public struct WordMean
    {
        /// <summary>
        /// 词性
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        public string Mean { get; set; }
        public override string ToString()
        {
            return Mean;
        }
    }
}
