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
        private IDictionary<string, string> engDictionary;
        private IDictionary<string,string> EngDictionary
        {
            get
            {
                if (engDictionary == null)
                {
                    engDictionary=new Dictionary<string, string>();
                    engDictionary = ld2Parse.Parse(Ld2FilePath);
                    //foreach (var word in engDictionary.Keys)
                    //{
                    //    var means = StringHelper.GetCoreDescriptions(engDictionary[word]);
                    //    engDictionary[word] = means.Count>0? means[0]:"";
                    //}
                }
                return engDictionary;
            }
        }
        /// <summary>
        /// 字典的路径
        /// </summary>
        public string Ld2FilePath { get; set; }
        public  string GetChineseMean(string word)
        {
            if(EngDictionary.ContainsKey(word))
            return EngDictionary[word];
            return "";
        }
        public bool IsInDictionary(string word)
        {
            return EngDictionary.ContainsKey(word);
        }

       
    }
}
