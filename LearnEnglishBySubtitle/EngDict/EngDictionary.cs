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
        /// <summary>
        /// 默认的意思
        /// </summary>
        public WordMean DefaultMean { get; set; }
        /// <summary>
        /// XML注释内容
        /// </summary>
        public  string Detail { get; set; }
    }
    public class WordMean
    {
        /// <summary>
        /// 在字典中的位置
        /// </summary>
        public long Index { get; set; }
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
            if (Property != null && Mean != null)
            {
                return Property+" "+ Mean;
            }
            else
            {
                return null;
            }
        }
    }
}
