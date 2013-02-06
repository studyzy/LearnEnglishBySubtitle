using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Studyzy.LeanEnglishBySubtitle.UserData;

namespace Studyzy.LeanEnglishBySubtitle.UnitTest
{
    class WebServiceTest
    {
        private static int USER_ID = 11009764;
        [Test]
        public void TestGetUserItems()
        {
            var list = HujiangWebService.GetUserItems(USER_ID, Convert.ToDateTime("2000-1-1"));

           Assert.Greater(list.Count,0);
            foreach (var str in list)
            {
                Debug.WriteLine(str);
            }
        }
        [Test]
        public void TestGetPublicBooks()
        {
            var books = HujiangWebService.GetPublicBooks(USER_ID, "en");
            Assert.Greater(books.Count, 0);
            foreach (var book in books)
            {
                Debug.WriteLine(book);
            }
        }
        [Test]
        public void TestGetUserBook()
        {
            var books = HujiangWebService.GetUserBook(USER_ID, 10445);
            Assert.Greater(books.Count, 0);
            foreach (var book in books)
            {
                Debug.WriteLine(book);
            }
        }
    }
}
