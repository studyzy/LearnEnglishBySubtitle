using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Import.Hujiang
{
   
    public class Book
    {
        
        public int BookID { get; set; }

        
        public string BookName { get; set; }

        
        public int ItemNum { get; set; }

        
        public int UnitNum { get; set; }

        
        public bool IsFinished { get; set; }

        public override string ToString()
        {
            return "Book[" + BookID + "] " + BookName + "," + ItemNum + "," + UnitNum;
        }
    }
}
