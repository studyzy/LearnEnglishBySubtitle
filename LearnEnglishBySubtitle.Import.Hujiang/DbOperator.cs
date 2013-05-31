using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SQLite;
using NHibernate;
using NHibernate.Linq;
using Studyzy.LearnEnglishBySubtitle.Import.Hujiang.Entities;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
{
    public class DbOperator
    {
        private ILog logger = LogManager.GetLogger(typeof (DbOperator));
        NHibernateHelper helper;
        public DbOperator(string fileName = "HJBookDB")
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


        #region Cichang Data
    
        public IList<CK_BookItem> GetBookItems(int bookId,int unitId)
        {
            return FindAll<CK_BookItem>(i => i.Book.Id == bookId && i.Unit.Id == unitId);
        }
        public IList<CK_BookItem> GetBookItemsBelowMaxUnitId(int bookId, int maxUnitId)
        {
            return FindAll<CK_BookItem>(i => i.Book.Id == bookId && i.Unit.Id <= maxUnitId);
        }

        #endregion


     
    }
}
