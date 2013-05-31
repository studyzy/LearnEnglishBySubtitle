using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NHibernate;
using NUnit.Framework;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.UnitTest
{
    public class DbTest
    {
      
        //[Test]
        //public void TestInsertEngDic()
        //{
        //    DbOperator dbOperator=new DbOperator();


        //    var count = dbOperator.Count<EngDictionary>();
        //    Assert.AreEqual(count, 0);

        //    dbOperator.InsertEngDictionary("an","一个，介词");
        //    count = dbOperator.Count<EngDictionary>();
        //    Assert.AreEqual(count,1);

        //    dbOperator.InsertEngDictionary("study", "学习");
        //    count = dbOperator.Count<EngDictionary>();
        //    Assert.AreEqual(count, 2);
        //}
        [Test]
        public void TestInsertVocabularyRank()
        {
            var txt = FileOperationHelper.ReadFile("klsrank.txt");
            DbOperator dbOperator=new DbOperator();
            dbOperator.BeginTran();
            foreach (var line in txt.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries))
            {
                var array = line.Split(',');
                VocabularyRank rank=new VocabularyRank(){Word = array[0],RankValue =Convert.ToInt32(array[1])};
                dbOperator.Save(rank);
            }
            dbOperator.Commit();
        }
        //[Test]
        //public void TestBatchInsert()
        //{
        //    DbOperator myDbOperator = new DbOperator();
        //    DbOperator dbOperator = new DbOperator("HJBookDB.db");
        //    var books= dbOperator.GetAll<CK_Books>();
        //    Assert.Greater(books.Count,0);
        //    Debug.WriteLine(books.Count);
        //    foreach (var book in books)
        //    {
        //        if (book.BookName.StartsWith("沪江英语"))
        //        {
        //            Debug.WriteLine(book.BookName + "," + book.Units.Count + "," + book.Items.Count);
        //            myDbOperator.BeginTran();
        //            foreach (var item in book.Items)
        //            {
        //                myDbOperator.InsertWordRank(item.Word,book.BookName);
        //            }
        //            myDbOperator.Commit();
        //        }
        //    }
        //}
        [Test]
        public void TestInsertVocabulary()
        {
            StreamReader sr=new StreamReader("Vocabulary.txt");
            var txt = sr.ReadToEnd();
            sr.Close();
            var lines = txt.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<Vocabulary>();
            foreach (var line in lines)
            {
                list.Add(new Vocabulary(){Word = line.Split(',')[1]});
            }
            Service service=new Service();
            Debug.WriteLine("Start:"+DateTime.Now);
            service.SaveUserVocabulary(list,"单元测试");
            Debug.WriteLine("Finish:" + DateTime.Now);
        }
    }
}
