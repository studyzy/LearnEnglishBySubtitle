using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
   public class WordRank
    {
        /// <summary>
        /// 单词
        /// </summary>
        public virtual string Word { get; set; }
        /// <summary>
        /// 词频的分级
        /// </summary>
        public virtual Rank Rank { get; set; }

        public virtual string Source { get; set; }
        /// <summary>
        /// 我是否已经知道这个词汇
        /// </summary>
        public virtual KnownStatus KnownStatus { get; set; }
    }
}
