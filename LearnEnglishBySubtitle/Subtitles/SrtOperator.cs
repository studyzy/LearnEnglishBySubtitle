using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public class SrtOperator : ISubtitleOperator
    {
        public Subtitle Parse(string str)
        {
            var result = new Dictionary<int, SubtitleLine>();
            var blocks = str.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            foreach (var block in blocks)
            {
                var array = block.Split(new string[] {"\r","\n"}, StringSplitOptions.RemoveEmptyEntries);
                var srt = new SubtitleLine();
                var num = array[0];
                srt.Number = ++index;

                var tarray = array[1].Split(new string[] { " --> " }, StringSplitOptions.RemoveEmptyEntries);
                srt.StartTime = Convert.ToDateTime("2000-01-01 " + tarray[0].Replace(',', '.').Replace(" ",""));
                srt.EndTime = Convert.ToDateTime("2000-01-01 " + tarray[1].Replace(',', '.').Replace(" ", ""));

                
                srt.Text = "";
                for (var i = 2; i < array.Length;i++ )
                    srt.Text += array[i]+"\r\n";
                if (srt.Text != "")
                {
                    srt.Text= srt.Text.Remove(srt.Text.Length - 2, 2);
                }
                result.Add(index,srt);
            }
            Subtitle st = new Subtitle(){Bodies=result};
            //ReCalcSequence(st);
            return st;
        }

        //private void ReCalcSequence(Subtitle subtitle)
        //{
        //    var newList = subtitle.Bodies.OrderBy(l => l.StartTime).ToList();
        //    for (var i = 1; i < newList.Count; i++)
        //    {
        //        newList[i].Number = i;
        //    }
        //    subtitle.Bodies = newList;
        //}

        public  string Subtitle2String(Subtitle st )
        {
            StringBuilder sb=new StringBuilder();
            var srts = st.Bodies;
            foreach (var kv in srts)
            {
                var subtitleLine = kv.Value;
                sb.Append(subtitleLine.Number);
                sb.Append("\r\n");
                sb.Append(subtitleLine.StartTime.ToString("HH:mm:ss,fff") + " --> " + subtitleLine.EndTime.ToString("HH:mm:ss,fff"));
                sb.Append("\r\n");
                sb.Append(subtitleLine.Text);
                sb.Append("\r\n\r\n");
            }
            var result = sb.ToString();
            return result.Remove(result.Length - 4);
        }

        public Subtitle RemoveChinese(Subtitle subtitle)
        {
            var newSrts = new Dictionary<int, SubtitleLine>();
            var srts = subtitle.Bodies;
            for (int i = 1; i <= subtitle.Bodies.Count; i++)
            {
                var subtitleLine = srts[i];
                var lines = subtitleLine.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                IList<string> newLines = new List<string>();
                foreach (var line in lines)
                {
                    var l = StringHelper.RemoveRemark(line);
                    if (!StringHelper.IsChinese(l))
                    {
                        newLines.Add(l);
                    }
                }
                if (newLines.Count > 0)
                {
                    subtitleLine.EnglishText = string.Join("\r\n", newLines.ToArray());
                }
                else
                {
                    subtitleLine.EnglishText = " ";
                }
                newSrts.Add(subtitleLine.Number, subtitleLine);
            }
            subtitle.Bodies= newSrts;
            return subtitle;
        }
        private static Regex formatRegex=new Regex("{[^}]+}");
        public Subtitle RemoveFormat(Subtitle subtitle)
        {
            foreach (KeyValuePair<int, SubtitleLine> subtitleLine in subtitle.Bodies)
            {
                subtitle.Bodies[subtitleLine.Key].EnglishText = formatRegex.Replace(subtitleLine.Value.EnglishText, "");
            }
            return subtitle;
        }
    }

   
}
