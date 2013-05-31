using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang.Entities
{
    /// <summary>
    /// 单词书
    /// </summary>
    public class CK_Books
    {
        public virtual int Id { get; set; }
        public virtual string BookName { get; set; }
        public virtual string Langs { get; set; }
        public virtual IList<CK_BookUnit> Units { get; set; }
        /// <summary>
        /// 一本书中的单词
        /// </summary>
        public virtual IList<CK_BookItem> Items { get; set; } 
    }
}
