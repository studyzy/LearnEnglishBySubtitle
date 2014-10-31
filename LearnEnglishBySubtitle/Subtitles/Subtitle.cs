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
            Bodies=new Dictionary<int, SubtitleLine>();
        }
        public string Header { get; set; }
        public string Footer { get; set; }
        public IDictionary<int,SubtitleLine> Bodies { get; set; } 
    }
}
