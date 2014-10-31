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
using StringReader = java.io.StringReader;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class SentenceParse
    {
        private static MaxentTagger tagger;
        private static SentenceParse instance;
        private SentenceParse()
        {
            //dictionaryService=new ViconDictionaryService();
           string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           var model = currentFolder + @"\models\english-bidirectional-distsim.tagger";
            // Loading POS Tagger
            tagger = new MaxentTagger(model);
        }

        public static SentenceParse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance=new SentenceParse();
                }
                return instance;
            }
        }

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
            var d = Global.DictionaryService.GetChineseMeanInDict(word.ToLower());
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
            var wordList = Parse(sentence)+" ";
            Regex regex=new Regex("\\b"+word+ @"/(.*?)\s");
            var match = regex.Match(wordList);
            var p= match.Groups[1].Value;
            //var kv = wordList.SingleOrDefault(w => w.Key == word);
            var pro = ConvertTag(p);
            var mean = originalMean.Means.FirstOrDefault(m => m.Property == pro);
            if (mean != null)
            {
                originalMean.DefaultMean = mean;
                return originalMean;
            }
           mean= d.Means.FirstOrDefault(m => m.Property == pro);
           if (mean != null)
           {
               d.DefaultMean = mean;
               return d;
           }
            return d;

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
