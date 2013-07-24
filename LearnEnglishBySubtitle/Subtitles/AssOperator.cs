using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public class AssOperator : ISubtitleOperator
    {
        public Subtitle Parse(string str)
        {
            Subtitle subtitle=new Subtitle();
            var eIndex = str.IndexOf("[Events]");
            var head = str.Substring(0, eIndex);
            str = str.Substring(eIndex);
            var diagIndex = str.IndexOf("Dialogue");
            head += str.Substring(0, diagIndex);
            subtitle.Header = head;
            str = str.Substring(diagIndex);
            var lines = str.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                subtitle.Bodies.Add(ParseLine(line));
            }
            return subtitle;
        }
        private SubtitleLine ParseLine(string line)
        {
            SubtitleLine subtitleLine=new SubtitleLine();
            var array = line.Split(',');
            subtitleLine.StartTime = Convert.ToDateTime("2000-01-01 " + array[1]);
            subtitleLine.EndTime = Convert.ToDateTime("2000-01-01 " + array[2]);
            subtitleLine.OriginalText = line;
            subtitleLine.Text = array[9];
            if (array.Length > 10)
            {
                for (int i = 10; i < array.Length; i++)
                {
                    subtitleLine.Text += "," + array[i];
                }
            }
            return subtitleLine;
        }

        public string Subtitle2String(Subtitle st)
        {
           StringBuilder sb=new StringBuilder();
            sb.Append(st.Header);
            foreach (var subtitleLine in st.Bodies)
            {
                sb.Append(Line2String(subtitleLine));
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
        private string Line2String(SubtitleLine line)
        {
            var array = line.OriginalText.Split(',');
            StringBuilder sb=new StringBuilder();
            sb.Append(array[0]);
            sb.Append(",");
            sb.Append(line.StartTime.ToString("H:mm:ss.ff"));
            sb.Append(",");
            sb.Append(line.EndTime.ToString("H:mm:ss.ff"));
            sb.Append(",");
            sb.Append(array[3]);
            sb.Append(",");
            sb.Append(array[4]);
            sb.Append(",");
            sb.Append(array[5]);
            sb.Append(",");
            sb.Append(array[6]);
            sb.Append(",");
            sb.Append(array[7]);
            sb.Append(",");
            sb.Append(array[8]);
            sb.Append(",");
            sb.Append(line.Text);
            return sb.ToString();
        }
        public Subtitle RemoveChinese(Subtitle subtitle)
        {
            var newSrts = new List<SubtitleLine>();
            var srts = subtitle.Bodies;
            for (int i = 0; i < subtitle.Bodies.Count; i++)
            {
                var SubtitleLine = srts[i];
                var lines = SubtitleLine.Text.Split(new string[] { "\r","\n","\\N" }, StringSplitOptions.RemoveEmptyEntries);
                IList<string> newLines = new List<string>();
                foreach (var line in lines)
                {
                    var l = StringHelper.RemoveRemark2(line);
                    if (!StringHelper.IsChinese(l))
                    {
                        newLines.Add(l);
                    }
                }
                if (newLines.Count > 0)
                {
                    SubtitleLine.EnglishText = string.Join("\r\n", newLines.ToArray());
                }
                else
                {
                    SubtitleLine.EnglishText = " ";
                }
                newSrts.Add(SubtitleLine);
            }
            subtitle.Bodies = newSrts;
            return subtitle;
        }
    }
}
