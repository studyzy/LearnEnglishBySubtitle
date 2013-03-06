using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    /// <summary>
    /// 英汉字典，包含对每个英文单词的解释
    /// </summary>
    public class EngDictionary
    {
        public virtual string Word { get; set; }
        public virtual IList<string> Means { get; set; }
        public virtual string Detail { get; set; }
    }
}
