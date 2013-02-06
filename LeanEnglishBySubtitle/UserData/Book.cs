using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.UserData
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public string BookName { get; set; }

        [DataMember]
        public int ItemNum { get; set; }

        [DataMember]
        public int UnitNum { get; set; }

        [DataMember]
        public bool IsFinished { get; set; }

        public override string ToString()
        {
            return "Book[" + BookID + "] " + BookName + "," + ItemNum + "," + UnitNum;
        }
    }
}
