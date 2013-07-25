using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.EngDict;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class SubtitleWord
    {
        public SubtitleWord()
        {
            IsNewWord = true;
        }
        /// <summary>
        /// 单词原型
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// 单词在字幕中的形式
        /// </summary>
        public string WordInSubitle { get; set; }
        public bool IsNewWord { get; set; }
        public string SubtitleSentence { get; set; }
        public IList<WordMean> Means { get; set; }
        public string SelectMean { get; set; }
    }
}
