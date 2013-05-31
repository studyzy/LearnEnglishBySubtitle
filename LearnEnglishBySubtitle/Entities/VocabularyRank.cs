using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 柯林斯词频分级数据，1-5级，1最少用，5最常用
    /// </summary>
    public class VocabularyRank
    {
        /// <summary>
        /// 单词
        /// </summary>
        public virtual string Word { get; set; }
        /// <summary>
        /// 词频的分级
        /// </summary>
        public virtual int RankValue { get; set; }

     
    }
}
