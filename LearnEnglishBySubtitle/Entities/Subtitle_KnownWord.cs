using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 用户通过界面确认的已知词汇
    /// </summary>
    public class Subtitle_KnownWord
    {
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        public virtual DateTime AddTime { get; set; }
    }
}
