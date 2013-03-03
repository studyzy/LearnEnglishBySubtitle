using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
    public class User_Vocabulary
    {
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        /// <summary>
        /// 我是否已经知道这个词汇
        /// </summary>
        public virtual KnownStatus KnownStatus { get; set; }
    }
}
