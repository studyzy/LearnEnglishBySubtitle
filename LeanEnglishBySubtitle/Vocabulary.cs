using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle
{
    public class Vocabulary
    {
        public string Word { get; set; }
        public bool IsKnown { get; set; }
        public override string ToString()
        {
            return Word + ":" + (IsKnown ? "Y" : "N");
        }
    }
}
