using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Subtitles
{
    public interface ISubtitleOperator
    {
        Subtitle Parse(string str);
        string Subtitle2String(Subtitle st);
        Subtitle RemoveChinese(Subtitle subtitle);
        Subtitle RemoveFormat(Subtitle subtitle);
    }
}
