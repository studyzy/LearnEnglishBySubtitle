using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
{
    public static class HujiangWebService
    {
        /// <summary>
        /// 获得用户的生词本
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public static IList<string> GetUserItems(int userId, DateTime lastDate)
        {
            //GET /services/mobileservice2.asmx/GetUserItems?userid=string&lastDate=string HTTP/1.1
            //Host: cichang.hujiang.com
            string url = "http://cichang.hujiang.com/services/mobileservice2.asmx/GetUserItems?userid={0}&lastDate={1}";
            //WebClient client = new WebClient();
            
            //byte[] data = client.DownloadData(string.Format(url, userId, lastDate));
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof (UserItems));
            //var result = (UserItems) obj.ReadObject(stream);
            var json = HttpHelper.GetResponse(string.Format(url, userId, lastDate));
            var result = JsonConvert.DeserializeObject<UserItems>(json);
            return result.WordList.Select(w => w.Word).ToList();
        }

       
        private class UserItems
        {
            
            public int TotalCount { get; set; }

            
            public int UserID { get; set; }

            
            public IList<Words> WordList { get; set; }
        }

       
        private class Words
        {
            
            public string Word { get; set; }


            public string WordDef { get; set; }

            
            //public int WordSID { get; set; }
        }
       
        private class UserUnitMax
        {
            
            public int Result { get; set; }

            
            public int UnitID { get; set; }

            
            public int UnitIndex { get; set; }
        }

        /// <summary>
        /// 获得所有公开的书本列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="langs"></param>
        /// <returns></returns>
        public static IList<Book> GetPublicBooks(int userId, string langs)
        {
            //            GET /services/mobileservice2.asmx/GetPublicBooks?userid=string&langs=string HTTP/1.1
            //Host: cichang.hujiang.com
            string url = "http://cichang.hujiang.com/services/mobileservice2.asmx/GetPublicBooks?userid={0}&langs={1}";
            //WebClient client = new WebClient();
            //byte[] data = client.DownloadData(string.Format(url, userId, langs));
            //Stream stream = new MemoryStream(data);

            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof (List<Book>));
            //var result = (List<Book>) obj.ReadObject(stream);

            var json = HttpHelper.GetResponse(string.Format(url, userId, langs));
            var result = JsonConvert.DeserializeObject<List<Book>>(json);
            return result;

        }
        /// <summary>
        /// 获得用户针对某本书的学习情况，返回最大的已背诵单元Id。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static int GetUserUnitMax(int userId,int bookId)
        {
            //GET /services/mobileservice2.asmx/GetUserUnitMax?userid=string&bookid=string&unitid=string&unitindex=string HTTP/1.1
            string url =
                "http://cichang.hujiang.com/services/mobileservice2.asmx/GetUserUnitMax?userid={0}&bookid={1}&unitid=0&unitindex=0";
            //WebClient client = new WebClient();
            //byte[] data = client.DownloadData(string.Format(url, userId, bookId));
            //Stream stream = new MemoryStream(data);

            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UserUnitMax));
            //var result = (UserUnitMax)obj.ReadObject(stream);
            var json = HttpHelper.GetResponse(string.Format(url, userId, bookId));

            var result = JsonConvert.DeserializeObject<UserUnitMax>(json);
            if (result.Result == 1)
            {
                return result.UnitID;
            }
            else
            {
                return 0;
            }
        }
      
        /// <summary>
        /// 获得用户对指定书本的单元完成情况
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static IList<UserBookUnitStatus> GetUserBook(int userId, int bookId)
        {
            //            GET /services/mobileservice.asmx/GetUserBook?userid=string&bookid=string HTTP/1.1
            //Host: cichang.hujiang.com
            string url = "http://cichang.hujiang.com/services/mobileservice.asmx/GetUserBook?userid={0}&bookid={1}";
            //WebClient client = new WebClient();
            //byte[] data = client.DownloadData(string.Format(url, userId, bookId));
            //Stream stream = new MemoryStream(data);

            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<UserBookUnitStatus>));
            //var result = (List<UserBookUnitStatus>)obj.ReadObject(stream);
            var json = HttpHelper.GetResponse(string.Format(url, userId, bookId));

            var result = JsonConvert.DeserializeObject<List<UserBookUnitStatus>>(json);
            return result;
        }

      
    }
}
