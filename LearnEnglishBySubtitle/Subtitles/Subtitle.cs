using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public class Subtitle
    {
        public Subtitle()
        {
            Bodies=new List<SubtitleLine>();
        }
        public string Header { get; set; }
        public string Footer { get; set; }
        public IList<SubtitleLine> Bodies { get; set; } 
    }
}
