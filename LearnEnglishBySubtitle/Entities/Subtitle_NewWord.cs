using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 记录了用户的生词
    /// </summary>
    [Table("Subtitle_NewWord")]
    public class Subtitle_NewWord
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        public KnownStatus KnownStatus { get; set; }
        public virtual string SubtitleName	 { get; set; }
        public virtual string Sentence { get; set; }
        public virtual string WordMean { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
