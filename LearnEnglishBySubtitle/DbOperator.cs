using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SQLite;
using Studyzy.LearnEnglishBySubtitle.Entities;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class DbOperator
    {
        private ILog logger = LogManager.GetLogger(typeof (DbOperator));

        private EfContext context;
        private DbOperator()
        {
            context=new EfContext();
        }

        private static DbOperator op = null;

        public static DbOperator Instance
        {
            get
            {
                if (op == null)
                {
                    op = new DbOperator();
                }
                return op;
            }
        }

     

        private DbContextTransaction transaction;

        public void BeginTran()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
            transaction = null;
        }

        private void RunSql(string sql)
        {
            context.Database.ExecuteSqlCommand(sql);
        }

       
        //public T FindOne<T>(Expression<Func<T, bool>> expression) where T : class
        //{
        //    return Session.QueryOver<T>().Where(expression).SingleOrDefault();
        //}

        //public T FindFirst<T>(Expression<Func<T, bool>> expression) where T : class
        //{
        //    return Session.Query<T>().Where(expression).FirstOrDefault();
        //}

        //public IList<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
        //{
        //    return Session.QueryOver<T>().Where(expression).List();
        //}

        //public IList<T> GetAll<T>() where T : class
        //{
        //    //return Session.QueryOver<T>().List();
        //    return context.Database.SqlQuery<T>("").ToList();
        //}

        public IList<UserVocabulary> GetAllUserVocabulary()
        {
            return context.UserVocabulary.ToList();
        }

        public void AddIgnoreWord(string word)
        {
            var q = context.IgnoreWords.SingleOrDefault(w => w.Word == word);
            if (q == null)
            {
                context.IgnoreWords.Add(new IgnoreWord() {CreateTime = DateTime.Now, Word = word});
                context.SaveChanges();
            }
        }

        public IList<IgnoreWord> GetAllIgnoreWords()
        {
            return context.IgnoreWords.ToList();
        }

        public IList<UserVocabulary> FindAllUserVocabulary(Expression<Func<UserVocabulary,bool>> funExpression)
        {
            return context.UserVocabulary.Where(funExpression).ToList();
        }
        public void SaveUserVocabulary(UserVocabulary userVocabulary)
        {
            context.UserVocabulary.AddOrUpdate(userVocabulary);
            context.SaveChanges();
        }

      

        #region User Data


        public void ClearUserVocabulary()
        {

            RunSql("delete from User_Vocabulary");

        }

        public void SaveUserKnownWords(IList<string> words)
        {
            BeginTran();

            foreach (var w in words)
            {

                Subtitle_KnownWord word = new Subtitle_KnownWord() {AddTime = DateTime.Now, Word = w};
                context.KnownWords.Add(word);
                UserVocabulary vocabulary = context.UserVocabulary.SingleOrDefault(v => v.Word == w);
                if (vocabulary == null)
                {
                    vocabulary = new UserVocabulary();
                }

                vocabulary.Word = w;
                vocabulary.Source = "Subtitle";
                vocabulary.KnownStatus = KnownStatus.Known;
                context.UserVocabulary.AddOrUpdate(vocabulary);
                context.SaveChanges();
            }
            Commit();
        }

        //public UserVocabulary GetUserVocabulary(string word)
        //{
        //    return FindFirst<UserVocabulary>(v => v.Word == word);
        //}

        public void SaveSubtitleNewWords(IList<SubtitleWord> newWords, string subtitleName)
        {
            BeginTran();
            RunSql("delete from Subtitle_NewWord where SubtitleName='" +subtitleName.Replace("'", "''") + "'");
            
            foreach (var userNewWord in newWords.Distinct())
            {
                Subtitle_NewWord entity = new Subtitle_NewWord()
                                              {
                                                  Word = userNewWord.Word,
                                                  SubtitleName = subtitleName,
                                                  Sentence = userNewWord.SubtitleSentence,
                                                  WordMean = userNewWord.SelectMean
                                              };
                context.NewWords.Add(entity);

                UserVocabulary vocabulary = context.UserVocabulary.SingleOrDefault(v => v.Word == userNewWord.Word);
                if (vocabulary == null)
                {
                    vocabulary = new UserVocabulary();
                }

                vocabulary.Word = userNewWord.Word;
                vocabulary.Source = "Subtitle";
                vocabulary.KnownStatus = KnownStatus.Unknown;
                context.UserVocabulary.AddOrUpdate(vocabulary);
                context.SaveChanges();
            }
            Commit();
        }

        #endregion

        public void InitDatabase()
        {
            context.Database.ExecuteSqlCommand(InnerDictionary.InitDb);
          
        }
    }
}
