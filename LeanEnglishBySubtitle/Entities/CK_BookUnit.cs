using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
    /// <summary>
    /// 单元
    /// </summary>
    public class CK_BookUnit
    {
        public virtual int Id { get; set; }
        public virtual int UnitId { get; set; }
        public virtual string UnitTitle { get; set; }
        public virtual CK_Books Book { get; set; }
        public virtual IList<CK_BookItem> Items { get; set; } 
    }
}
