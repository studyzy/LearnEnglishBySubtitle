using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    /// <summary>
    /// 一条字幕
    /// </summary>
    public class SubtitleLine
    {
        public string OriginalText { get; set; }
        public int Number { get; set; }
        /// <summary>
        /// 字幕内容部分
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 字幕中的英文部分
        /// </summary>
        public string EnglishText { get; set; }
        /// <summary>
        /// 注释后的英文部分字幕
        /// </summary>
        public string EnglishTextWithMeans { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
