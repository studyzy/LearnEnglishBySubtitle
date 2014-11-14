using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using com.sun.tools.javac.util;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle
{
    internal class PronunciationDownloader
    {
        private static ILog logger = LogManager.GetLogger("PronunciationDownloader");

        public static void DownloadPronunciation()
        {
            if (!Global.PronunciationDownload)
            {
                return;
            }
            var words =
                DbOperator.Instance.GetAllUserVocabulary()
                    .Select(w => w.Word)
                    .OrderBy(v => v).ToList();
            string pathFolder =Global.PronunciationType;

            ThreadPool.SetMaxThreads(100, 100);

            foreach (var word in words)
            {
                string filePath = pathFolder + "\\" + word + ".mp3";
                if (!  File.Exists(filePath))
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {

                        string url = string.Format("http://dict.youdao.com/dictvoice?audio={0}&type={1}", word, Global.PronunciationType=="UK"?1:2);
                        DownloadFile(url, filePath);
                    }, null);
                }
            }
        }

        private static void DownloadFile(string url, string path)
        {
            try
            {
                WebClient Client = new WebClient();
                Client.DownloadFile(url, path);
            }
            catch (Exception ex)
            {
                logger.Error("download from url:" + url, ex);
            }
        }
        private static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public static void DownloadAndPlay(string word)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                string pathFolder = Global.PronunciationType;
                string filePath = pathFolder + "\\" + word + ".mp3";
                if (!File.Exists(filePath))
                {
                    string url =
                        string.Format(
                            "http://dict.youdao.com/dictvoice?audio={0}&type={1}",
                            word,
                            Global.PronunciationType == "UK" ? 1 : 2);

                    DownloadFile(url, filePath);
                }
                try
                {
                 
                    player.URL = filePath;
                    player.controls.play();

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }));
            thread.Start();
        }

    }
}
