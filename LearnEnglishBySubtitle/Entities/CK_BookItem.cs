using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
    /// <summary>
    /// 单词
    /// </summary>
    public class CK_BookItem
    {
        public virtual int Id { get; set; }
        public virtual string Word { get; set; }
        public virtual int WordId	 { get; set; }
        public virtual CK_BookUnit Unit { get; set; }
        public virtual CK_Books Book { get; set; }
    }
}
