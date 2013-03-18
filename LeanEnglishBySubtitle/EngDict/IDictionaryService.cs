using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    internal interface IDictionaryService
    {
        string Ld2FilePath { get; set; }
        string DictionaryName { get; set; }
      
        EngDictionary GetChineseMeanInDict(string word);
        bool IsInDictionary(string word);
    }
}
