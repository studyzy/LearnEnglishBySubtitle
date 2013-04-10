using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle
{
    public class Service
    {
       

        private DbOperator dbOperator=new DbOperator();

        public void SaveUserVocabulary(IList<Vocabulary> userWords,string source )
        {
            var allUserVocabulary = dbOperator.GetAll<UserVocabulary>();


            dbOperator.BeginTran();
            foreach (var word in userWords)
            {
                var dbWord = allUserVocabulary.SingleOrDefault(v => v.Word == word.Word);
                if (dbWord != null)
                {
                    dbWord.KnownStatus = word.IsKnown ? KnownStatus.Known : KnownStatus.Unknown;
                    dbWord.Source = source;
                    dbOperator.Save(dbWord);
                }
                else
                {
                    UserVocabulary uv = new UserVocabulary() { Word = word.Word,Source = source,KnownStatus = word.IsKnown ? KnownStatus.Known : KnownStatus.Unknown };
                    allUserVocabulary.Add(uv);
                    dbOperator.Save(uv);
                }
            }
           
            dbOperator.Commit();
        }
    }
}
