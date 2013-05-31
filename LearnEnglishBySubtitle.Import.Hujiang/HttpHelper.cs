using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
{
    class HttpHelper
    {
        public static string GetResponse(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(url);
            }
        }
    }
}
