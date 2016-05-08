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
            IsStar = false;
        }
        /// <summary>
        /// 是否是标星的单词
        /// </summary>
        public bool IsStar { get; set; }
        /// <summary>
        /// 在该字母中的词频
        /// </summary>
        public int ShowCount { get; set; }
        /// <summary>
        /// 单词原型
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// 单词在字幕中的形式
        /// </summary>
        public IList<string> WordInSubtitle { get; set; }=new List<string>();
        public bool IsNewWord { get; set; }
        public string SubtitleSentence { get; set; }
        public IList<WordMean> Means { get; set; }
        public string SelectMean { get; set; }
    }
}
