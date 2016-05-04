using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SQLite;
using com.sun.org.apache.bcel.@internal.generic;
using Studyzy.LearnEnglishBySubtitle.Entities;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class DbOperator
    {
        private ILog logger = LogManager.GetLogger(typeof (DbOperator));
        private ILog eflogger = LogManager.GetLogger("Entity Framework");

        private EfContext context;
        private DbOperator()
        {
            context=new EfContext();
#if DEBUG
            context.Database.Log = l => eflogger.Debug(l);
#endif
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

        public string GetConfigValue(string key)
        {
            var config = context.Configs.SingleOrDefault(c => c.ConfigKey == key);
            return config==null?null:config.ConfigValue;
        }

        public void SetConfigValue(string key, string value)
        {
            Config config=new Config(){ConfigKey = key,ConfigValue = value};
            context.Configs.AddOrUpdate(config);
            context.SaveChanges();
        }
        public void SaveUserVocabulary(IList<Vocabulary> userWords, string source)
        {
            var allUserVocabulary = GetAllUserVocabulary();


            BeginTran();
            foreach (var word in userWords)
            {
                var dbWord = allUserVocabulary.SingleOrDefault(v => v.Word == word.Word);
                if (dbWord != null)
                {
                    dbWord.KnownStatus = word.IsKnown ? KnownStatus.Known : KnownStatus.Unknown;
                    dbWord.Source = source;
                    SaveUserVocabulary(dbWord);
                }
                else
                {

                    UserVocabulary uv = new UserVocabulary() { Word = word.Word, Source = source, KnownStatus = word.IsKnown ? KnownStatus.Known : KnownStatus.Unknown };
                    allUserVocabulary.Add(uv);
                    //SaveUserVocabulary(uv);
                }
            }

            Commit();
        }
        public UserVocabulary GetUserWord(string word)
        {
            var words = FindAllUserVocabulary(u => u.Word == word.Trim());
            if (words.Count == 0)
            {
                return null;
            }
            return words[0];
        }

        public void DeleteWord(string word)
        {
            DeleteSubtitleWords(word);
            DeleteUserVocabulary(word);
        }

        public IList<UserVocabulary> GetAllUserVocabulary()
        {
            return context.UserVocabulary.ToList();
        }
        public IList<UserVocabulary> GetAllUserKnownVocabulary()
        {
            return context.UserVocabulary.Where(v=>v.KnownStatus== KnownStatus.Known).ToList();
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

        public void UpdateStarFlag(string word,bool isStar)
        {
            var wrd = context.UserVocabulary.SingleOrDefault(w => w.Word == word);
            if (wrd != null)
            {
                wrd.IsStar = isStar;
                context.UserVocabulary.AddOrUpdate(wrd);
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

        public void DeleteUserVocabulary(string word)
        {
            var u = context.UserVocabulary.SingleOrDefault(w => w.Word == word);
            if (u != null)
            {
                context.UserVocabulary.Remove(u);
                context.SaveChanges();
            }
        }
        public void DeleteSubtitleWords(string word)
        {
            var list= context.NewWords.Where(w => w.Word == word);
            context.NewWords.RemoveRange(list);
            context.SaveChanges();
        }
        public IList<Subtitle_NewWord> FindSubtitleWords(string word)
        {
            return context.NewWords.Where(w => w.Word == word).ToList();
        }

        public void SaveUserVocabulary(UserVocabulary userVocabulary)
        {

            context.UserVocabulary.AddOrUpdate(userVocabulary);
            context.SaveChanges();
        }

      

        #region User Data


        public void ClearUserVocabulary()
        {
            RunSql("delete from IgnoreWord");
            RunSql("delete from UserVocabulary");
            RunSql("delete from Subtitle_NewWord");

        }

        //public void SaveUserKnownWords(IList<string> words)
        //{
        //    BeginTran();

        //    foreach (var w in words)
        //    {

        //        Subtitle_KnownWord word = new Subtitle_KnownWord() {AddTime = DateTime.Now, Word = w};
        //        context.KnownWords.Add(word);
        //        UserVocabulary vocabulary = context.UserVocabulary.SingleOrDefault(v => v.Word == w);
        //        if (vocabulary == null)
        //        {
        //            vocabulary = new UserVocabulary();
        //        }

        //        vocabulary.Word = w;
        //        vocabulary.Source = "Subtitle";
        //        vocabulary.KnownStatus = KnownStatus.Known;
        //        context.UserVocabulary.AddOrUpdate(vocabulary);
        //        context.SaveChanges();
        //    }
        //    Commit();
        //}

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
                                                  WordMean = userNewWord.SelectMean,
                                                  CreateTime = DateTime.Now,
                                                  KnownStatus = userNewWord.IsNewWord?KnownStatus.Unknown : KnownStatus.Known
                                              };
                context.NewWords.Add(entity);

                UserVocabulary vocabulary = context.UserVocabulary.SingleOrDefault(v => v.Word == userNewWord.Word);
                if (vocabulary == null)
                {
                    vocabulary = new UserVocabulary();
                    vocabulary.CreateTime = DateTime.Now;
                }

                vocabulary.Word = userNewWord.Word;
                vocabulary.Source = "字幕";
                vocabulary.Sentence = userNewWord.SubtitleSentence;
                vocabulary.KnownStatus = userNewWord.IsNewWord ? KnownStatus.Unknown : KnownStatus.Known;
                vocabulary.UpdateTime = DateTime.Now;
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
