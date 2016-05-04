using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Studyzy.LearnEnglishBySubtitle;
using Studyzy.LearnEnglishBySubtitle.EngDict;

namespace Studyzy.LeanEnglishBySubtitle.UnitTest
{
    class SentenceParseTest
    {

        
        [TestCase("This is my doing", "doing","do","doing","n.")]
        [TestCase("You are doing homework.", "doing","do","do","v.")]
        public void TestVerbIng(string sentence, string word,string originalWord,string decideWord, string property)
        {
            //DictionaryService service=new ViconDictionaryService();
            //var dic = service.GetChineseMeanInDict(word);
            //var dic2 = service.GetChineseMeanInDict(originalWord);
          
            var r = new SentenceParse().RemarkWord(sentence,word,originalWord);
            Assert.AreEqual(r.DefaultMean.Property, property);
            Assert.AreEqual(r.Word,decideWord);
        }
        [TestCase("I want to date you.","date","v.")]
        [TestCase("This is a good date.","date","n.")]
        [TestCase("My father broke his clavicle.", "broke", "v.")]
        public void Test1Word2Properties(string sentence, string word, string property)
        {
            //DictionaryService service = new ViconDictionaryService();
            //var dic = service.GetChineseMeanInDict(word);
            var r = new SentenceParse().RemarkWord(sentence,word,word);
            Assert.AreEqual(r.DefaultMean.Property, property);
        }

    }
}
