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

        [TestCase("you can do it", "do","v.")]
        [TestCase("This is my doing", "doing","n.")]
        public void TestVerbIng(string sentence, string word, string property)
        {
            DictionaryService service=new ViconDictionaryService();
            var dic = service.GetChineseMeanInDict(word);
            var r = SentenceParse.GetWordMean(sentence,dic);
            Assert.AreEqual(r.Property, property);
        }

    }
}
