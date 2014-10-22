using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 记录用户忽略的表
    /// </summary>
    [Table("IgnoreWord")]
    public class IgnoreWord
    {
        /// <summary>
        /// 主键，自增ID
        /// </summary>
        [Key]
        public  long Id { get; set; }
        public  string Word { get; set; }
    
        public  DateTime CreateTime { get; set; }
     
    }
}
