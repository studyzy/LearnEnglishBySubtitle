using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
     [Table("Config")]
    public class Config
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
    
    }
}
