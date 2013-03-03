using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
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
