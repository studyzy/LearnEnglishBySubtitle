using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Remotion.Linq.Utilities;

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
                default:throw new Exception("unkown file extension:"+ex);
            }
        }
    }
}
