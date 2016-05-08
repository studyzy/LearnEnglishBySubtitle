using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 记录用户认识和不认识单词的表
    /// </summary>
    [Table("UserVocabulary")]
    public class UserVocabulary : IAuditEntity
    {
        /// <summary>
        /// 主键，自增ID
        /// </summary>
        [Key]
        public  long Id { get; set; }
        public  string Word { get; set; }
        /// <summary>
        /// 我是否已经知道这个词汇
        /// </summary>
        public  KnownStatus KnownStatus { get; set; }
        /// <summary>
        /// 这个状态是从哪个系统得知的
        /// </summary>
        public  string Source { get; set; }
        /// <summary>
        /// 例句
        /// </summary>
        public string Sentence { get; set; }
        /// <summary>
        /// 是否加星（加星表示这个单词很重要，以后每次出现，我都应该着重显示）
        /// </summary>
        public bool IsStar { get; set; }
        public  DateTime CreateTime { get; set; }
        public  DateTime UpdateTime { get; set; }
    }
}
