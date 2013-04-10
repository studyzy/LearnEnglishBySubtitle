using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle
{
    public interface IAuditEntity
    {
          DateTime CreateTime { get; set; }
          DateTime UpdateTime { get; set; }
    }
}
