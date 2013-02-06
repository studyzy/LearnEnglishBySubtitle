using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NHibernate;
using NUnit.Framework;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle.UnitTest
{
    public class DbTest
    {
      
        [Test]
        public void TestInsertEngDic()
        {
            DbOperator dbOperator=new DbOperator();


            var count = dbOperator.Count<EngDictionary>();
            Assert.AreEqual(count, 0);

            dbOperator.InsertEngDictionary("an","一个，介词");
            count = dbOperator.Count<EngDictionary>();
            Assert.AreEqual(count,1);

            dbOperator.InsertEngDictionary("study", "学习");
            count = dbOperator.Count<EngDictionary>();
            Assert.AreEqual(count, 2);
        }
        [Test]
        public void TestBatchInsert()
        {
            DbOperator myDbOperator = new DbOperator();
            DbOperator dbOperator = new DbOperator("HJBookDB.db");
            var books= dbOperator.GetAll<CK_Books>();
            Assert.Greater(books.Count,0);
            Debug.WriteLine(books.Count);
            foreach (var book in books)
            {
                if (book.BookName.StartsWith("沪江英语"))
                {
                    Debug.WriteLine(book.BookName + "," + book.Units.Count + "," + book.Items.Count);
                    myDbOperator.BeginTran();
                    foreach (var item in book.Items)
                    {
                        myDbOperator.InsertWordRank(item.Word,book.BookName);
                    }
                    myDbOperator.Commit();
                }
            }
        }
    }
}
