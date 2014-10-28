using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.EngDict;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class SentenceParse
    {

        public static WordMean GetWordMean(string sentence, EngDictionary word)
        {
            foreach (WordMean mean in word.Means)
            {
                if (mean.Property == "n.")
                {
                    if (IsNoun(sentence, word.Word))
                    {
                        return mean;
                    }
                }
            }
            //无法判断就选第一个解释
            return word.Means[0];
        }

        private static bool IsNoun(string sentence, string word)
        {
            return true;
        }

        private static DictionaryService dictionaryService=new ViconDictionaryService();

        private static IList<string[]> GetPropertyList(string sentence)
        {
            sentence=GetOriginalSentence(sentence);

            return null;
        }

        /// <summary>
        /// 替换掉其中的简写部分，还原成非简写形式
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string GetOriginalSentence(string sentence)
        {
            if (sentence.IndexOf("'") > 0)
            {
                sentence= sentence.Replace("I'm", "I am");
                sentence= sentence.Replace("'re", " are");
                sentence= sentence.Replace("n't", " not");
                sentence= sentence.Replace("'d", " would");
                sentence= sentence.Replace("'n", " and");
                sentence= sentence.Replace("'ll", " will");
                sentence= sentence.Replace("'s", " is");
                //'s 最复杂
                
            }

            return sentence;
        }

        public static string[] SplitSentence(string sentence)
        {
            var array = sentence.Split(new char[] { ' ', ',', '.', '?', ':', '!' }, StringSplitOptions.RemoveEmptyEntries);
            return array;
        }
    }
}
