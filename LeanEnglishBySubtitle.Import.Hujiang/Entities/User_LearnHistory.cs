using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Import.Hujiang.Entities
{
    /// <summary>
    /// 记录了用户的开心词场学习记录，从而得知哪些单词用户已经认识了
    /// </summary>
    public class User_LearnHistory
    {
        public virtual int Id { get; set; }
        
        public virtual int BookId	 { get; set; }
        public virtual int MaxUnitId { get; set; } 
    }
}
