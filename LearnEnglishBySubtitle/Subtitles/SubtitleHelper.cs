using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public static class SubtitleHelper
    {
        public static ISubtitleOperator GetOperatorByFileName(string fileName)
        {
            var ex = Path.GetExtension(fileName).ToLower();
            switch (ex)
            {
                case ".srt":return new SrtOperator();
                case ".ass":return new AssOperator();
                case ".txt":return new TxtOperator();
                default:throw new Exception("unkown file extension:"+ex);
            }
        }
    }
}
