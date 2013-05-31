using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.UserData
{
    [DataContract]
    public class UserBookUnitStatus
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public int UnitID { get; set; }

        [DataMember]
        public int UnitIndex { get; set; }

        [DataMember]
        public bool IsFinished { get; set; }
        public override string ToString()
        {
            return BookID + "," + UnitID + "," + IsFinished;
        }
    }
}
