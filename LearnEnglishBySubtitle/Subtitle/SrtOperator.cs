using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitle
{
    public class SrtOperator
    {
        public static IList<SrtFormat> Parse(string str)
        {
            var result = new List<SrtFormat>();
            var blocks = str.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var block in blocks)
            {
                var array = block.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                SrtFormat srt = new SrtFormat();
                var num = array[0];
                srt.Number = Convert.ToInt32(num);
                srt.StartEndTime = array[1];
                srt.Text = "";
                for (var i = 2; i < array.Length;i++ )
                    srt.Text += array[i]+"\r\n";
                srt.Text= srt.Text.Remove(srt.Text.Length - 2, 2);
                result.Add(srt);
            }
          
            return result;
        }
        public static string SrtFormat2String(IList<SrtFormat> srts )
        {
            StringBuilder sb=new StringBuilder();
            foreach (var srtFormat in srts)
            {
                sb.Append(srtFormat.Number);
                sb.Append("\r\n");
                sb.Append(srtFormat.StartEndTime);
                sb.Append("\r\n");
                sb.Append(srtFormat.Text);
                sb.Append("\r\n\r\n");
            }
            var result = sb.ToString();
            return result.Remove(result.Length - 4);
        }
    }

    public struct SrtFormat
    {
        public int Number { get; set; }

        public string StartEndTime
        {
            get { return StartTime.ToString("HH:mm:ss,fff") + " --> " + EndTime.ToString("HH:mm:ss,fff"); }
            set
            {
                var array = value.Split(new string[] {" --> "}, StringSplitOptions.RemoveEmptyEntries);
                StartTime = Convert.ToDateTime("2000-01-01 " + array[0].Replace(',','.'));
                EndTime = Convert.ToDateTime("2000-01-01 " + array[1].Replace(',', '.'));
            }
        }

        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
