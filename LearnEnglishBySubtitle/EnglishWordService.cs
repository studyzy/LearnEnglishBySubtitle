using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class EnglishWordService
    {
        //private DbOperator dbOperator =  DbOperator.Instance;
        private DictionaryService dictionaryService;

        //public DictionaryService DictionaryService
        //{
        //    set { dictionaryService = value; }
        //}

        public EnglishWordService()
        {
            this.dictionaryService = Global.DictionaryService;
        }

        //private IList<VocabularyRank> rankData;

        private bool IsInRankTable(string word)
        {
            return GetRank(word) > 3;
        }

        private int GetRank(string word)
        {
            var rankData = InnerDictionaryHelper.GetAllVocabularyRanks();
            if (rankData.ContainsKey(word))
            {
                return rankData[word];
            }
            return -1;
            //if (rankData == null)
            //{
            //    rankData = dbOperator.GetAll<VocabularyRank>();
            //}
            //var x = rankData.SingleOrDefault(r => r.Word == word);
            //if (x == null)
            //{
            //    return -1;
            //}
            //return x.RankValue;
        }

        /// <summary>
        /// 传入一个英文单词，获得其原型
        /// 逻辑如下：
        /// 先转换为小写。
        /// 然后查一下是否在单词和原型表中有，有则返回原型。
        /// 查看词频表中是否有，有则说明单词本身就是原型。
        /// 判断词的后缀，是ing还是es、s、ed，如果是，则可能是变形，按如下规则找：
        ///     去掉后缀后，查看是否是一个单词，如果是，那么就是原型，如果不是：
        ///     加上e，或者i变成y，或者去掉双写末尾字母，还不是就再加e。
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string GetOriginalWord(string word)
        {
            //if (word == "I" || word == "I'm")
            //    return word;
            //word = RemoveSimpleWrite(word);
            if (word.ToUpper() == word) //全大写
            {
                return word;
            }
            word = word.ToLower();
           

            var original = GetOriginalWordFromDb(word);
            if (original != null)
            {
                return original;
            }
            //if (IsInRankTable(word))
            //{
            //    return word;
            //}
            //if (word.Length > 4 && word.EndsWith("ing")) //进行时
            //{
            //    return OperateIngWord(word);
            //}
            //if (word.Length > 3 && (word.EndsWith("ed"))) //过去式
            //{
            //    return OperateEdWord(word);
            //}
            //if (word.Length > 3 && word.EndsWith("es")) //复数
            //{
            //    return OperateEsWord(word);
            //}
            //else if (word.EndsWith("s") && word.Length > 3 && word[word.Length - 2] != 's') //复数
            //{
            //    return OperateSWord(word);
            //}
            return word;
        }

       

        private string OperateIngWord(string word)
        {
            var newWord = word.Substring(0, word.Length - 3);
            if (!dictionaryService.IsInDictionary(newWord) && newWord[newWord.Length - 1] == newWord[newWord.Length - 2])
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
            return word;
        }

        private string OperateEdWord(string word)
        {
            var newWord = word.Substring(0, word.Length - 2);
            if (newWord.EndsWith("i"))
            {
                //dried->dry
                newWord = newWord.Substring(0, newWord.Length - 1) + "y";
            }
            if (!dictionaryService.IsInDictionary(newWord) && newWord[newWord.Length - 1] == newWord[newWord.Length - 2])
            {
                //stopped->stop
                newWord = newWord.Substring(0, newWord.Length - 1);
            }
            return OperateIfAddE(newWord); 
            //if (dictionaryService.IsInDictionary(newWord))
            //{
            //    if (IsSameMean(newWord, word))
            //        return newWord;
            //    var n = newWord + "e";
            //    if (dictionaryService.IsInDictionary(n))
            //    {
            //        return n;
            //    }
            //    else
            //    {
            //        return newWord;
            //    }

            //}
            //newWord += "e";
            //if (dictionaryService.IsInDictionary(newWord))
            //{
            //    return newWord;
            //}
            //return word;
        }

        private string OperateEsWord(string word)
        {
            //与Ed结果的变化不同的是，这里不会出现双写结尾的变化
            var newWord = word.Substring(0, word.Length - 2);
            if (newWord.EndsWith("i"))
            {
                //dies->die
                var addeWord = OperateIfAddE(newWord);
                if (addeWord != newWord)
                {
                    return addeWord;
                }
                //dries->dry
                newWord = newWord.Substring(0, newWord.Length - 1) + "y";
            }

            return OperateIfAddE(newWord);
        }

        private string OperateSWord(string word)
        {
            var newWord = word.Substring(0, word.Length - 1);
            if (dictionaryService.IsInDictionary(newWord))
            {
                return newWord;
            }
            return word;
        }
        /// <summary>
        /// 传入一个已经去掉词Es、Ed后缀的单词，判断是否需要加上e结尾,如果加e后是一个单词，那就返回加e的单词， 如果加3不是单词，那么返回原单词
        /// </summary>
        /// <param name="newWord"></param>
        /// <returns></returns>
        private string OperateIfAddE(string newWord)
        {
            var rank1 = GetRank(newWord);
            
            var addEword = newWord + "e";
            var rank2 = GetRank(addEword);
            if (rank1>0&&rank2>0)//加不加e都是单词
            {
                if (rank1 > rank2)
                {
                    return newWord;
                }
                return addEword;
            }
            if (rank1 > 0 && rank2 < 0)
            {
                return newWord;
            }
            if (rank1 < 0 && rank2 > 0)
            {
                return addEword;
            }

            if (dictionaryService.IsInDictionary(addEword))
            {
                return addEword;
            }
            return newWord;
        }
        private IDictionary<string, string> OriginalWordMaps;

        /// <summary>
        /// 获得不规则动词的Mapping，返回不规则动词的原型
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string GetOriginalWordFromDb(string word)
        {
            OriginalWordMaps = InnerDictionaryHelper.GetAllWordOriginalMaps();
            //if (OriginalWordMaps == null)
            //{
            //    OriginalWordMaps = new Dictionary<string, string>();
            //    var list = dbOperator.GetAll<WordOriginalMap>();
            //    foreach (var wordOriginalMap in list)
            //    {
            //        OriginalWordMaps.Add(wordOriginalMap.Word, wordOriginalMap.OriginalWord);
            //    }
            //}
            if (OriginalWordMaps.ContainsKey(word))
            {
                return OriginalWordMaps[word];
            }
            return null;
        }


      
    }
}
