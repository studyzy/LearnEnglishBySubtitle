using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Studyzy.LeanEnglishBySubtitle.EngDict;

namespace Studyzy.LeanEnglishBySubtitle.UnitTest
{
    class EnglishServiceTest
    {
        EnglishWordService service=new EnglishWordService(new LangdaoE2CDictionaryService());

        [TestCase("doing","do")]
        [TestCase("stopping","stop")]
        [TestCase("deciding", "decide")]
        public void TestVerbIng(string word,string result)
        {
            var o= service.GetOriginalWord(word);
            Assert .AreEqual(o,result);
        }

        [TestCase("stopped","stop")]
        [TestCase("studied", "study")]
        [TestCase("fired", "fire")]
        public void TestVerbEd(string word, string result)
        {
            var o = service.GetOriginalWord(word);
            Assert.AreEqual(o, result);
        }
        [TestCase("does", "do")]
        public void TestVerbEs(string word, string result)
        {
            var o = service.GetOriginalWord(word);
            Assert.AreEqual(o, result);
        }
        [TestCase("did", "do")]
        [TestCase("made", "make")]
        public void TestSpeicalVerb(string word, string result)
        {
            var o = service.GetOriginalWord(word);
            Assert.AreEqual(o, result);
        }


        [TestCase("dries", "dry")]
        [TestCase("books","book")]
        [TestCase("houses", "house")]
        [TestCase("churches", "church")]
        [TestCase("fires", "fire")]

        public void TestAddEsOrS(string word, string result)
        {
            var o = service.GetOriginalWord(word);
            Assert.AreEqual(o, result);
        }
         [TestCase("tired")]
        [TestCase("morning")]
        [TestCase("always")]
        [TestCase("miss")]
        public void TestKeepSame(string word)
        {
            var o = service.GetOriginalWord(word);
            Assert.AreEqual(o, word);
        }
    }
}
