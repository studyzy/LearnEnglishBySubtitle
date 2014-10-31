using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.EngDict
{
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
                return Property + " " + Mean;
            }
            else
            {
                return null;
            }
        }
    }
}
