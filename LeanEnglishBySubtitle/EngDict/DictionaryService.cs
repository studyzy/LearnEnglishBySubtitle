using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.Helpers;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    public class DictionaryService
    {
        private static DictionaryService instance=new DictionaryService();
        public static DictionaryService Instance{get { return instance; }}
        private DictionaryService()
        {
            Ld2FilePath = "Modern.ld2";
        }
        private LingoesLd2 ld2Parse=new LingoesLd2();
        private IDictionary<string, EngDictionary> engDictionary;
        private IDictionary<string, EngDictionary> EngDictionary
        {
            get
            {
                if (engDictionary == null)
                {
                    engDictionary = new Dictionary<string, EngDictionary>();
                    var dictionary = ld2Parse.Parse(Ld2FilePath);
                    foreach (var word in dictionary.Keys)
                    {
                        var means = StringHelper.GetCoreDescriptions(dictionary[word]);
                        if (!engDictionary.ContainsKey(word))
                        {
                            engDictionary.Add(word,new EngDictionary(){Word = word,Detail = dictionary[word],Means = means});
                        }
                    }
                }
                return engDictionary;
            }
        }
        /// <summary>
        /// 字典的路径
        /// </summary>
        public string Ld2FilePath { get; set; }
        public  IList<string> GetChineseMean(string word)
        {
            if(EngDictionary.ContainsKey(word))
            return EngDictionary[word].Means;
            return new List<string>();
        }
        public EngDictionary GetChineseMeanInDict(string word)
        {
            if (EngDictionary.ContainsKey(word))
                return EngDictionary[word];
            return null;
        }
        public bool IsInDictionary(string word)
        {
            return EngDictionary.ContainsKey(word);
        }

       
    }
}
