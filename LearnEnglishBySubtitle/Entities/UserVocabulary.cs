using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Entities
{
    /// <summary>
    /// 记录用户认识和不认识单词的表
    /// </summary>
    public class UserVocabulary : IAuditEntity
    {
        /// <summary>
        /// 主键，自增ID
        /// </summary>
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        /// <summary>
        /// 我是否已经知道这个词汇
        /// </summary>
        public virtual KnownStatus KnownStatus { get; set; }
        /// <summary>
        /// 这个状态是从哪个系统得知的
        /// </summary>
        public virtual string Source { get; set; }

        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
    }
}
