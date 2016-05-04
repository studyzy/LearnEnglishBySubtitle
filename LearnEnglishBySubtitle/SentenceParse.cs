using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using com.sun.org.apache.bcel.@internal.generic;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using ikvm.extensions;
using java.util;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using StringReader = java.io.StringReader;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class SentenceParse
    {
        private static MaxentTagger tagger;
        //private static SentenceParse instance;
        public SentenceParse()
        {
            //dictionaryService=new ViconDictionaryService();
           //string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string currentFolder = System.AppDomain.CurrentDomain.BaseDirectory;
           var model = currentFolder + @"\models\english-bidirectional-distsim.tagger";
            // Loading POS Tagger
            if(tagger==null)
            tagger = new MaxentTagger(model);
        }

        //public static SentenceParse Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance=new SentenceParse();
        //        }
        //        return instance;
        //    }
        //}

        private string Parse(string subtitleLine)
        {
            //IList<KeyValuePair<string, string>> list=new List<KeyValuePair<string, string>>();
            string result = "";
            var sentences = MaxentTagger.tokenizeText(new StringReader(subtitleLine)).toArray();
            foreach (ArrayList sentence in sentences)
            {
                var taggedSentence = tagger.tagSentence(sentence);
                string r = Sentence.listToString(taggedSentence, false);
                result += r;
                //var array = result.Split(' ');
                //foreach (string s in array)
                //{
                //    var kv = s.Split('/');
                //    list.Add(new KeyValuePair<string, string>(kv[0],kv[1]));
                //}
            }
            return result;
        }


         private EnglishWordService englishWordService = new EnglishWordService();
        private IList<string> knownVocabulary;
        private IList<string> ignores;
        public IList<string> SpecialWords = new List<string>(); 
        /// <summary>
        /// 找出一个句子中的所有生词
        /// </summary>
        /// <param name="line">一句英文句子</param>
        /// <returns>Key为生词的原型，Value为生词在句子中的形式</returns>
        public IList<KeyValuePair<string,string>> Pickup(string line)
        {
            if (knownVocabulary == null)
            {
                knownVocabulary =
                    DbOperator.Instance.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known)
                        .Select(v => v.Word.ToLower())
                        .ToList();
                ignores = DbOperator.Instance.GetAllIgnoreWords().Select(v => v.Word).ToList();
            }
            var orgLine = GetOriginalSentence(line);
            var sentences = GetSentences(orgLine);
            var array = SplitSentence2Words(orgLine);
            var result = new List<KeyValuePair<string, string>>();
            foreach (string w in array)
            {
                var wordLow = w.ToLower();
                if (IsEasyWord(wordLow))
                {
                    continue;
                }
                if (IsEnglishName(w))
                {
                    //英文名，忽略
                    continue;
                }
                if (IsSpecialName(w, sentences))
                {
                    if (!SpecialWords.Contains(w))
                    {
                        SpecialWords.Add(w);
                    }
                    continue;
                }
                if(w[0]>='A'&&w[0]<='Z')//首字母大写的情况下，判断这个单词是不是特殊词汇，如果是，则保持首字母大写
                {
                    if (Global.DictionaryService.IsInDictionary(w))
                    {
                        if (knownVocabulary.Contains(w) || ignores.Contains(w))
                        {
                            //认识的单词，忽略
                            continue;
                        }
                        result.Add(new KeyValuePair<string, string>(w, w));
                        continue;
                    }
                }
                var original = englishWordService.GetOriginalWord(wordLow);
               
                if (knownVocabulary.Contains(wordLow) || knownVocabulary.Contains(original) || ignores.Contains(wordLow) ||
                    ignores.Contains(original))
                {
                    //认识的单词，忽略
                    continue;
                }
                result.Add(new KeyValuePair<string, string>(original,w));
               

               
            }
            return result;
        }
        /// <summary>
        /// 首字母大写，但是找到的解释的词却不是首字母大写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sentences"></param>
        /// <returns></returns>
        private bool IsSpecialName(string s, IEnumerable<string> sentences)
        {
            char firstChar = s[0];
            if (firstChar >= 'A' && firstChar <= 'Z')//首字母大写
            {
                if (SpecialWords.Contains(s))
                {
                    return true;
                }
                if (s.ToUpper() == s)//全是大写字母
                {
                    return true;
                }
                foreach (var sentence in sentences)
                {
                    if (sentence.IndexOf(s, StringComparison.Ordinal) > 0)
                    {
                        var mean = Global.DictionaryService.GetChineseMeanInDict(s);
                        if (mean == null)//首字母大写的情况下，找不到意思，按特殊词处理
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 把一段话拆分成多个句子
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private IList<string> GetSentences(string line)
        {
            return line.Split(new[] {'.', '"', '\r', '\n', '?', '!'},StringSplitOptions.RemoveEmptyEntries)
                .Select(s=>s.Trim()).ToList();//去掉句子前后的空格
          
        }

        private static string[] EasyWordPart = new[] {"re", "m", "s", "t", "d", "n", "ll"};
        private bool IsEasyWord(string word)
        {
            if (EasyWordPart.Contains(word))
            {
                return true;
            }
            var easyWord = InnerDictionaryHelper.GetAllEasyWords();
            return easyWord.Contains(word);
        }
        /// <summary>
        /// 判断是否是英文名，首字母大写，而且在英文名列表中的就是英文名
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool IsEnglishName(string word)
        {
            if (word[0] >= 'A' && word[0] <= 'Z')
            {
                var names = InnerDictionaryHelper.GetAllEnglishNames();
                return names.Contains(word);
            }
            return false;
        }
       


        //private DictionaryService dictionaryService;
        /// <summary>
        /// 根据一个句子，找到一个单词在句子中的意思
        /// </summary>
        /// <param name="sentence">单词所在句子</param>
        /// <param name="word">单词本身</param>
        /// <param name="original">单词的原型</param>
        /// <returns></returns>
        public EngDictionary RemarkWord(string sentence, string word, string original)
        {
            if (word.Length == 1)
            {
                return null;
            }
            var d = Global.DictionaryService.GetChineseMeanInDict(word);
            if (d == null)
            {
                d = Global.DictionaryService.GetChineseMeanInDict(word.ToLower());
            }
            var originalMean = Global.DictionaryService.GetChineseMeanInDict(original);
            if (d == null ||d.Means.Count == 1)//只有一个解释，那么就不用判断了,返回原型的解释
            {
                if (originalMean != null)
                {
                    return originalMean;
                }
                return d;
            }
            if (originalMean == null)
            {
                originalMean = d;
            }
            var pro = GetTag(word, sentence);
            WordMean mean = null;
            if (pro!=null)//知道单词的词性
            {
                mean = originalMean.Means.FirstOrDefault(m => m.Property == pro);
            }
            else//不知道词性，就去取第一个意思
            {
                mean = originalMean.Means.FirstOrDefault();
            }
            if (mean != null)
            {
                originalMean.DefaultMean = mean;
                return originalMean;
            }
            //根本没有所谓的原型形式，直接用该单词查找意思。
            if (pro != null)//知道单词的词性
            {
                mean = d.Means.FirstOrDefault(m => m.Property == pro);
            }
            else//不知道词性，就去取第一个意思
            {
                mean = d.Means.FirstOrDefault();
            }

           if (mean != null)
           {
               d.DefaultMean = mean;
               return d;
           }
            return d;

        }

        private string GetTag(string word, string sentence)
        {
            var wordList = Parse(sentence) + " ";
            Regex regex = new Regex("\\b" + word + @"/(.*?)\s");
            var match = regex.Match(wordList);

            if (match.Success) //知道单词的词性
            {
                var p = match.Groups[1].Value;
                var pro = ConvertTag(p);
                return pro;
            }
            return null;
        }

        private const string mappingTable = @"CC	conj.
CD	n.
DT	
EX	
FW	
IN	conj.
JJ	adj.
JJR	adj.
JJS	adj.
LS	
MD	v.
NN	n.
NNS	n.
NNP	n.
NNPS	n.
PDT	
POS	
PRP	pron.
PRP$	pron.
RB	adv.
RBR	adv.
RBS	adv.
RP	
SYM	
TO	
UH	
VB	v.
VBD	v.
VBG	v.
VBN	v.
VBP	v.
VBZ	v.
WDT	
WP	pron.
WP$	pron.
WRB	adv.";
        private static IDictionary<string, string> mappingDict; 
        private string ConvertTag(string tag)
        {
            if (mappingDict == null)
            {
                var array = mappingTable.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                mappingDict=new Dictionary<string, string>();
                foreach (string s in array)
                {
                    var kv = s.Split('\t');
                    mappingDict.Add(kv[0],kv[1]);
                }
            }
            return mappingDict[tag];
        }

       

        /// <summary>
        /// 替换掉其中的简写部分，还原成非简写形式
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string GetOriginalSentence(string sentence)
        {
            if (sentence.IndexOf("'") >= 0)
            {
                sentence= sentence.Replace("I'm", "I am");
                sentence= sentence.Replace("'re", " are");
                sentence = sentence.Replace("won't", "will not");
                sentence= sentence.Replace("n't", " not");
                sentence= sentence.Replace("'d", " would");
                sentence= sentence.Replace("'n", " and");
                sentence= sentence.Replace("'ll", " will");
                sentence= sentence.Replace("'ve", " have");
                //sentence = sentence.Replace("'s", " is");
                //'s 最复杂
                
            }

            return sentence;
        }
        /// <summary>
        /// 把句子拆分成单词
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string[] SplitSentence2Words(string sentence)
        {
            var array = sentence.Split(new char[] { ' ', ',', '.', '?', ':', '!','\'' }, StringSplitOptions.RemoveEmptyEntries);
            return array;
        }
        /// <summary>
        /// 将一个句子分成单词和符号（空格）组成的数组
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static ICollection<string> SplitSentence(string sentence)
        {
            List<string> result=new List<string>();
            StringBuilder sb=new StringBuilder();
            foreach (char c in sentence)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')||c=='-')
                {
                    sb.Append(c);
                }
                else
                {
                    string word = sb.ToString();
                    if (word != "")
                    {
                        result.Add(word);
                    }
                    sb.Clear();
                    result.Add(c.ToString());
                }
            }
            var last = sb.ToString();
            if (last != "")
            {
                result.Add(last);
            }
            return result;

        }
    }
}
