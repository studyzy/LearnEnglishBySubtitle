using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 用户通过界面确认的已知词汇
    /// </summary>
    [Table("Subtitle_KnownWord")]
    public class Subtitle_KnownWord
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        public virtual DateTime AddTime { get; set; }
    }
}
