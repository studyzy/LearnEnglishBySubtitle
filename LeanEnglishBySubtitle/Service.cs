using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle
{
    internal class Service
    {
        public Service(DbOperator dbOperator)
        {
            this.dbOperator = dbOperator;
        }

        private DbOperator dbOperator;

        public void CalcUserVocabulary(IList<string> userNewWords = null)
        {
            IList<string> newWords = new List<string>();
            if (userNewWords == null)
            {
                newWords = dbOperator.GetAll<User_NewWord>().Select(w => w.Word).ToList();
            }
            else
            {
                newWords = userNewWords;
            }
            dbOperator.BeginTran();
            dbOperator.ClearUserVocabulary();
            var histories = dbOperator.GetAll<User_LearnHistory>();
            foreach (var history in histories)
            {
                //读取已经背诵的单元
                for (var i = 1; i <= history.MaxUnitId; i++)
                {
                    var items = dbOperator.GetBookItems(history.BookId, i);
                    foreach (var bookItem in items)
                    {
                        User_Vocabulary vocabulary = new User_Vocabulary() {Word = bookItem.Word};
                        if (newWords.Contains(bookItem.Word))
                        {
                            vocabulary.KnownStatus = KnownStatus.DoNotKnow;
                        }
                        else
                        {
                            vocabulary.KnownStatus = KnownStatus.Known;
                        }
                        dbOperator.Save<User_Vocabulary>(vocabulary);
                    }
                }
            }
            dbOperator.Commit();
        }
    }
}
