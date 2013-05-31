using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 记录了用户的生词
    /// </summary>
    public class Subtitle_NewWord
    {
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        public virtual string SubtitleName	 { get; set; }
        public virtual string Sentence { get; set; }
        public virtual string WordMean { get; set; } 
    }
}
