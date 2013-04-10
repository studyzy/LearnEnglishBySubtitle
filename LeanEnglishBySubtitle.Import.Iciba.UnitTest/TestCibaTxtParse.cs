using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeanEnglishBySubtitle.Import.Iciba.UnitTest
{
    public class TestCibaTxtParse
    {
        [Test]
        public void TestParseWords()
        {
            var words = CibaTxtParseHelper.Parse("ciba.txt");
            Assert.IsNotNull(words);
            foreach (var word in words)
            {
                Debug.WriteLine(word);
            }
        }
    }
}
