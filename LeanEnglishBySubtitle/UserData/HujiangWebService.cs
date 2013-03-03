using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Studyzy.LeanEnglishBySubtitle.UserData
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
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(string.Format(url, userId, lastDate));
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof (UserItems));
            var result = (UserItems) obj.ReadObject(stream);
            return result.WordList.Select(w => w.Word).ToList();
        }

        [DataContract]
        private class UserItems
        {
            [DataMember]
            public int TotalCount { get; set; }

            [DataMember]
            public int UserID { get; set; }

            [DataMember]
            public IList<Words> WordList { get; set; }
        }

        [DataContract]
        private class Words
        {
            [DataMember]
            public string Word { get; set; }

            [DataMember]
            public int DictID { get; set; }

            [DataMember]
            public int WordSID { get; set; }
        }
        [DataContract]
        private class UserUnitMax
        {
            [DataMember]
            public int Result { get; set; }

            [DataMember]
            public int UnitID { get; set; }

            [DataMember]
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
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(string.Format(url, userId, langs));
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof (List<Book>));
            var result = (List<Book>) obj.ReadObject(stream);
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
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(string.Format(url, userId, bookId));
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UserUnitMax));
            var result = (UserUnitMax)obj.ReadObject(stream);
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
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(string.Format(url, userId, bookId));
            Stream stream = new MemoryStream(data);

            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<UserBookUnitStatus>));
            var result = (List<UserBookUnitStatus>)obj.ReadObject(stream);
            return result;
        }

      
    }
}
