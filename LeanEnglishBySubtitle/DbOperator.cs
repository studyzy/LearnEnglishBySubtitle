using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SQLite;
using NHibernate;
using NHibernate.Linq;
using Studyzy.LeanEnglishBySubtitle.Entities;
using log4net;

namespace Studyzy.LeanEnglishBySubtitle
{
    public class DbOperator
    {
        private ILog logger = LogManager.GetLogger(typeof (DbOperator));
        NHibernateHelper helper;
        public DbOperator(string fileName = "Dictionary.db3")
        {

            helper = new NHibernateHelper(fileName);
        }

        //public string ConnectionString
        //{
        //    get { return helper.Configuration.Properties["connection.connection_string"]; }
        //    set { helper.Configuration.Properties["connection.connection_string"] = value; }
        //}
        private ISession session;

        protected ISession Session
        {
            get
            {
                if (session == null)
                {
                    session = helper.GetSession();
                }
                return session;
            }
        }
        protected ISession NewSession
        {
            get { return helper.GetSession(); }
        }
        public int Count<T>() where T:class 
        {
            return Session.QueryOver<T>().RowCount();
        }
        //public void InsertEngDictionary(string word, string description)
        //{
        //    EngDictionary ed = new EngDictionary() {Word = word, Description = description};
        //    Session.SaveOrUpdate(ed);
        //    if (transaction == null)
        //        Session.Flush();
        //}
        //public void InsertWordRank(string word, string source)
        //{
        //    if (Session.QueryOver<VocabularyRank>().Where(w => w.Word == word).RowCount() == 0)
        //    {
        //        VocabularyRank ed = new VocabularyRank()
        //            {Word = word, Source = source, KnownStatus = KnownStatus.Unknown, Rank = Rank.Unknown};
        //        Session.Save(ed);
        //        if (transaction == null)
        //            Session.Flush();
        //    }
        //    else
        //    {
        //        logger.Info(word+" is in database");
        //    }
        //}

        private ITransaction transaction;
        public void BeginTran()
        {
            transaction = Session.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
            transaction = null;
        }
        //public string GetDecription(string word)
        //{
        //    var result= Session.QueryOver<EngDictionary>().Where(d => d.Word == word).SingleOrDefault();
        //    if (result == null)
        //    {
        //        return "";
        //    }
        //    return result.Description;
        //}
        //public T GetById<T>(long id) where T : class 
        //{
        //    return Session.CreateCriteria<T>().Add(Expression.Eq("Id", id)).UniqueResult<T>();
        //}
        public T FindOne<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Session.QueryOver<T>().Where(expression).SingleOrDefault();
        }
        public T FindFirst<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Session.Query<T>().Where(expression).FirstOrDefault();
        }
        public IList<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Session.QueryOver<T>().Where(expression).List();
        }
        public IList<T> GetAll<T>() where T : class
        {
            return Session.QueryOver<T>().List();
        }
        public T Save<T>(T obj) where T : class
        {
            Session.SaveOrUpdate(obj);
            return obj;
        }

        #region User Data
        
        public void SaveUserNewWords(IList<string> newWords )
        {
            BeginTran();
            var q= Session.CreateSQLQuery("delete from User_NewWord");
            q.ExecuteUpdate();
            foreach (var userNewWord in newWords.Distinct())
            {
                User_NewWord entity=new User_NewWord(){Word = userNewWord};
                Session.SaveOrUpdate(entity);
            }
            Commit();
        }
        public void SaveUserLearnHistory(IList<User_LearnHistory> histories )
        {
            BeginTran();
            var q = Session.CreateSQLQuery("delete from User_LearnHistory");
            q.ExecuteUpdate();
            foreach (var history in histories)
            {
                Session.SaveOrUpdate(history);
            }
            Commit();
        }
        public void ClearUserVocabulary()
        {
         
            var q = Session.CreateSQLQuery("delete from User_Vocabulary");
            q.ExecuteUpdate();

        }

        public void SaveUserKnownWords(IList<string> words )
        {
            BeginTran();

            foreach (var w in words)
            {
                UserKnownWord word=new UserKnownWord(){AddTime = DateTime.Now,Word = w};
                Session.SaveOrUpdate(word);
                User_Vocabulary vocabulary=new User_Vocabulary();
                vocabulary.Word = w;
                vocabulary.KnownStatus=KnownStatus.Known;
                Session.SaveOrUpdate(vocabulary);
            }
            Commit();
        }

        public User_Vocabulary GetUserVocabulary(string word)
        {
            return FindFirst<User_Vocabulary>(v => v.Word == word);
        }

        #endregion

        #region Cichang Data
    
        public IList<CK_BookItem> GetBookItems(int bookId,int unitId)
        {
            return FindAll<CK_BookItem>(i => i.Book.Id == bookId && i.Unit.Id == unitId);
        }
        #endregion


        public VocabularyRank GetVocabularyRank(string word)
        {
            return FindOne<VocabularyRank>(v => v.Word == word);
        }
    }
}
