using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 单词的变形和原型的对应
    /// </summary>
    public class WordOriginalMap
    {
        public virtual string Word { get; set; }
        public virtual string OriginalWord { get; set; }
    }
}
