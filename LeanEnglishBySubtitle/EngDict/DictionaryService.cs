using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.Helpers;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    public abstract class DictionaryService
    {
        //private static DictionaryService instance;
        //public static DictionaryService Instance{get { return instance; }}
        //private DictionaryService()
        //{
        //    Ld2FilePath = "Dictionary.ld2";
        //    DictionaryName = "";
        //}
        public abstract string DictionaryName { get; }
        protected LingoesLd2 ld2Parse = new LingoesLd2();
        protected static IDictionary<string, EngDictionary> engDictionary;
        protected IDictionary<string, EngDictionary> EngDictionary
        {
            get
            {
                if (engDictionary == null)
                {
                    engDictionary = new Dictionary<string, EngDictionary>();
                    ld2Parse.XmlEncoding = MeanEncoding;
                    ld2Parse.WordEncoding = WordEncoding;
                    var dictionary = ld2Parse.Parse("Dictionaries\\"+ Ld2FilePath);
                    foreach (var word in dictionary.Keys)
                    {
                        var means = GetCoreMeans(dictionary[word]);
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
        /// 传入XML格式的词语解释，返回其核心解释
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public abstract IList<string> GetCoreMeans(string xml);
        /// <summary>
        /// 字典的路径
        /// </summary>
        public abstract string Ld2FilePath { get; }

        public virtual Encoding MeanEncoding { get { return Encoding.UTF8; }}
        public virtual Encoding WordEncoding { get { return Encoding.UTF8; } }
        public virtual EngDictionary GetChineseMeanInDict(string word)
        {
            if (EngDictionary.ContainsKey(word))
                return EngDictionary[word];
            return null;
        }
        public virtual bool IsInDictionary(string word)
        {
            return EngDictionary.ContainsKey(word);
        }

       
    }
}
