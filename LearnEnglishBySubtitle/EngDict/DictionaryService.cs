using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.EngDict
{
    public abstract class DictionaryService
    {
        public DictionaryService()
        {
            IgnorePhrase = true;
        }
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
        public bool IgnorePhrase { get; set; }

        protected IDictionary<string, EngDictionary> EngDictionary
        {
            get
            {
                if (engDictionary == null)
                {
                    engDictionary = new Dictionary<string, EngDictionary>();
                    ld2Parse.XmlEncoding = MeanEncoding;
                    ld2Parse.WordEncoding = WordEncoding;
                    var dictionary = ld2Parse.Parse("Dictionaries\\" + Ld2FilePath);
#if DEBUG
                    StreamWriter sw = new StreamWriter("D:\\" + Ld2FilePath + ".txt", false, Encoding.UTF8);
#endif
                    foreach (var word in dictionary.Keys)
                    {
#if DEBUG
                        sw.WriteLine(word + "\t" + dictionary[word]);
#endif
                        if (IgnorePhrase && word.Contains(" "))
                        {
                            continue;
                        }
                        var means = GetCoreMeans(dictionary[word]);
                        if (!engDictionary.ContainsKey(word))
                        {
                            engDictionary.Add(word,
                                              new EngDictionary()
                                                  {Word = word, Detail = dictionary[word], Means = means});
                        }
                    }
#if DEBUG
                    sw.Close();
#endif
                }
                return engDictionary;
            }
        }

        /// <summary>
        /// 传入XML格式的词语解释，返回其核心解释
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public abstract IList<WordMean> GetCoreMeans(string xml);
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

        public virtual bool IsInDictionary(string word,string property)
        {
            if (EngDictionary.ContainsKey(word))
            {
                var means = EngDictionary[word].Means;
                foreach (var mean in means)
                {
                    if (mean.Property == property)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
