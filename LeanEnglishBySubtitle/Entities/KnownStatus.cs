using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.Entities
{
    /// <summary>
    /// 用户是否认识该单词
    /// </summary>
    public enum KnownStatus
    {
        /// <summary>
        /// 不知用户是否知道
        /// </summary>
        Unknown=0,
        /// <summary>
        /// 知道
        /// </summary>
        Known=1,
        /// <summary>
        /// 不知道
        /// </summary>
        DoNotKnow = 2
    }
}
