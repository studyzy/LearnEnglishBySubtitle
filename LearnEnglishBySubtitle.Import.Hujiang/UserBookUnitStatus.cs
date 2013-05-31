using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
{
  
    public class UserBookUnitStatus
    {
     
        public int BookID { get; set; }

     
        public int UnitID { get; set; }

    
        public int UnitIndex { get; set; }

    
        public bool IsFinished { get; set; }
        public override string ToString()
        {
            return BookID + "," + UnitID + "," + IsFinished;
        }
    }
}
