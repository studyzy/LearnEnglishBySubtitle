using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    class TxtOperator:ISubtitleOperator
    {
        public Subtitle Parse(string str)
        {
            Subtitle sb=new Subtitle();
            sb.Bodies=new Dictionary<int, SubtitleLine>();
            int rowIndex = 1;
            foreach (var line in str.Split(new []{'\r','\n'},StringSplitOptions.RemoveEmptyEntries))
            {
                sb.Bodies.Add(rowIndex,new SubtitleLine() {EnglishText = line,Number = rowIndex});
                rowIndex++;
            }
            return sb;
        }

        public string Subtitle2String(Subtitle st)
        {
           StringBuilder sb=new StringBuilder();
            foreach (var subtitleLine in st.Bodies.Values)
            {
                sb.Append(subtitleLine.EnglishTextWithMeans+"\r\n");
            }
            return sb.ToString();
        }

        public Subtitle RemoveChinese(Subtitle subtitle)
        {
            return subtitle;
        }

        public Subtitle RemoveFormat(Subtitle subtitle)
        {
            return subtitle;
        }
    }
}
