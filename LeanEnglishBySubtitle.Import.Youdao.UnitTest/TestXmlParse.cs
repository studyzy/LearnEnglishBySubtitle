using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeanEnglishBySubtitle.Import.Youdao.UnitTest
{
    public class TestXmlParse
    {
        [Test]
        public void TestParse2Vocabulary()
        {
            var result = XmlParseHelper.Parse("youdao.xml");
            Assert.IsNotNull(result);
            foreach (var vocabulary in result)
            {
                Debug.WriteLine(vocabulary.ToString());
            }
        }
    }
}
