using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using com.sun.org.apache.bcel.@internal.generic;
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

        /// <summary>
        /// 单词作为Key（区分大小写），意思作为Value的内存字典
        /// </summary>
        protected static IDictionary<string, EngDictionary> engDictionary;
        protected static IDictionary<string, string[]> wordProperties;

        /// <summary>
        /// 只关注单词，忽略短语
        /// </summary>
        public bool IgnorePhrase { get; set; }
        /// <summary>
        /// 词型变换的Mapping表
        /// </summary>
        protected IDictionary<string,string> WordMapping
        { get; set; }

        //private static Regex eregex=new Regex("<E>(.*?)</E>");
        protected IDictionary<string, EngDictionary> EngDictionary
        {
            get
            {
                if (engDictionary == null)
                {
                    engDictionary = new Dictionary<string, EngDictionary>();
                    wordProperties=new Dictionary<string, string[]>();
                    ld2Parse.XmlEncoding = MeanEncoding;
                    ld2Parse.WordEncoding = WordEncoding;
                    var dictionary = ld2Parse.Parse("Dictionaries\\" + Ld2FilePath);
#if DEBUG
                    StreamWriter sw = new StreamWriter("C:\\" + Ld2FilePath + ".txt", false, Encoding.UTF8);
#endif
                    foreach (var word in dictionary)
                    {
                        string xml = String.Join(",", word.Descriptions.Values);
#if DEBUG
                        sw.WriteLine(word.Word + "\t" + xml);

                        //if (eregex.IsMatch(xml))
                        //{
                        //    foreach (Match match in eregex.Matches(xml))
                        //    {
                        //        var value = match.Groups[1].Value;
                        //        var array = value.Split('|');
                        //        if (!array.Contains(word.Word))
                        //        {
                        //            foreach (var s in array)
                        //            {
                        //                sw.WriteLine(s + "\t" + word.Word);
                        //            }
                        //        }
                        //    }

                        //}
                        
#endif
                        if (IgnorePhrase && word.Word.Contains(" "))
                        {
                            continue;
                        }
                        var means = GetCoreMeans(xml);
                        if (!engDictionary.ContainsKey(word.Word))
                        {
                            var d = new EngDictionary() {Word = word.Word, Detail = xml, Means = means};
                            d.PhoneticSymbols = GetPhoneticSymbols(xml);
                            engDictionary.Add(word.Word,d);
                        }
                        if (!wordProperties.ContainsKey(word.Word))
                        {
                            var p = means.Select(m => m.Property).Distinct().ToArray();
                            wordProperties.Add(word.Word, p);
                        }
                    }
#if DEBUG
                    sw.Close();
#endif
                }
                return engDictionary;
            }
        }
        private static Regex phoneticRegex = new Regex("<M>(.*?)</M>");
        protected virtual string GetPhoneticSymbols(string xml)
        {
            if (phoneticRegex.IsMatch(xml))
            {
                return phoneticRegex.Match(xml).Groups[1].Value;
            }
            return null;
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
        /// <summary>
        /// 获得一个单词的词性
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string[] GetWordProperties(string word)
        {
            //存在于字典中就应该有词性
            if (EngDictionary.ContainsKey(word))
            {
                return wordProperties[word];
            }
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
