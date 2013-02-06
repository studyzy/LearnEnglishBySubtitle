using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Subtitle
{
    class SrtOperator
    {
        public IList<SrtFormat> Parse(string str)
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
                //srt.Text= srt.Text.Remove(srt.Text.Length - 2, 2);
                result.Add(srt);
            }
          
            return result;
        }
    }

    struct SrtFormat
    {
        public int Number { get; set; }
        public string StartEndTime { get; set; }
        public string Text { get; set; }
    }
}
