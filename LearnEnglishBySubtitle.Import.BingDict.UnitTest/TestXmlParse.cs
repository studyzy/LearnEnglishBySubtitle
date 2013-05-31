using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LearnEnglishBySubtitle.Import.BingDict.UnitTest
{
    public class TestXmlParse
    {

        [Test]
        public void TestParse2Vocabulary()
        {
            var result = XmlParseHelper.Parse("bing.xml");
            Assert.IsNotNull(result);
            foreach (var vocabulary in result)
            {
                Debug.WriteLine(vocabulary.ToString());
            }
        }
    }
}
