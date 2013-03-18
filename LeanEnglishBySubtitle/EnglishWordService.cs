using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.EngDict;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle
{
    public class EnglishWordService
    {
        private DbOperator dbOperator = new DbOperator();
        private DictionaryService dictionaryService ;
        public DictionaryService DictionaryService { set { dictionaryService = value; } }

        public EnglishWordService(DictionaryService dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }

        private IList<VocabularyRank> rankData; 
        private bool IsInRankTable(string word)
        {
            if(rankData==null)
            {
                rankData = dbOperator.GetAll<VocabularyRank>();
            }
            return rankData.Count(r => r.Word == word) > 0;
        }

        /// <summary>
        /// 传入一个英文单词，获得其原型
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public  string GetOriginalWord(string word)
        {
            if (word == "I" || word == "I'm")
                return word;
            if (word.ToUpper() == word)//全大写
            {
                return word;
            }
            word= word.ToLower();

            var original = GetOriginalWordFromDb(word);
            if (original != null)
            {
                return original;
            }
            if (IsInRankTable(word))
            {
                return word;
            }
            if (word.Length>4 && word.EndsWith("ing"))//进行时
            {
                var newWord = word.Substring(0, word.Length - 3);
                if (!dictionaryService.IsInDictionary(newWord)&&  newWord[newWord.Length - 1] == newWord[newWord.Length - 2])
                {
                    //stopping->stop
                    newWord = newWord.Substring(0, newWord.Length - 1);
                }
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
                newWord += "e";
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
            }
            if (word.Length>3 &&(word.EndsWith("ed")))//过去式
            {
                var newWord = word.Substring(0, word.Length - 2);
                if (newWord.EndsWith("i"))
                {
                    //dries->dry
                    newWord = newWord.Substring(0, newWord.Length - 1) + "y";
                }
                if (!dictionaryService.IsInDictionary(newWord)&& newWord[newWord.Length - 1] == newWord[newWord.Length - 2])
                {
                    //stopped->stop
                    newWord = newWord.Substring(0, newWord.Length - 1);
                }
                if (dictionaryService.IsInDictionary(newWord))
                {
                    if (IsSameMean(newWord, word))
                    return newWord;
                    var n= newWord + "e";
                    if (dictionaryService.IsInDictionary(n))
                    {
                        return n;
                    }
                    else
                    {
                        return newWord;
                    }

                }
                newWord += "e";
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
            }
            if (word.Length > 3 && word.EndsWith("es")) //复数
            {
                var newWord = word.Substring(0, word.Length - 2);
                if (newWord.EndsWith("i"))
                {
                    //dries->dry
                    newWord = newWord.Substring(0, newWord.Length - 1) + "y";
                }
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
                newWord += "e";
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
            }
            else if (word.EndsWith("s")&&word.Length>3&&word[word.Length-2]!='s')//复数
            {
                var newWord = word.Substring(0, word.Length - 1);
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
               
            }
            return word;
        }
        private Dictionary<string, string> OriginalWordMaps;
        /// <summary>
        /// 获得不规则动词的Mapping，返回不规则动词的原型
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string GetOriginalWordFromDb(string word)
        {
            if (OriginalWordMaps == null)
            {
                OriginalWordMaps = new Dictionary<string, string>();
                var list = dbOperator.GetAll<WordOriginalMap>();
                foreach (var wordOriginalMap in list)
                {
                    OriginalWordMaps.Add(wordOriginalMap.Word, wordOriginalMap.OriginalWord);
                }
            }
            if (OriginalWordMaps.ContainsKey(word))
            {
                return OriginalWordMaps[word];
            }
            return null;
        }


        private bool IsSameMean(string newWord, string oldWord)
        {
            var newMean = dictionaryService.GetChineseMeanInDict(newWord);
            var oldMean = dictionaryService.GetChineseMeanInDict(oldWord);
            if (newMean != null && oldMean == null)
            {
                return true;
            }
            if (newMean != null && newMean.Detail == oldMean.Detail)
            {
                return true;
            }
            return false;
        }
    }
}
