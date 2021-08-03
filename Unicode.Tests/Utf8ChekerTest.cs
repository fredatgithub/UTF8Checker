using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Unicode.Tests
{
    [TestFixture]
    public class Utf8ChekerTest
    {
        [Test]
        public void Test_Sample_Utf8()
        {  
            Assert.IsTrue(Test("utf8.html"));
        }

        [Test]
        public void Test_Russian_Utf8()
        {
            Assert.IsTrue(Test("ru.sql"));
        }

        [Test]
        public void Test_ucs2_cyr()
        {
            Assert.IsFalse(Test("cyr.txt"));
        }

        [Test]
        public void Test_utf8_extensive_demo()
        {
            Assert.IsTrue(Test("UTF-8-demo.txt"));
        }

        [Test]
        public void Test_utf8_BOM()
        {
            Assert.IsTrue(Test("utf8BOM.txt"));
        }

        [Test]
        public void Test_UTF8()
        {
            Assert.IsTrue(Test("UTF-8-test.txt"));
        }

        [Test]
        public void Test_UTF8_Illegal_311()
        {
            Assert.IsFalse(Test("UTF-8-test-illegal-311.txt"));
        }

        [Test]
        public void Test_UTF8_Illegal_312()
        {
            Assert.IsFalse(Test("UTF-8-test-illegal-312.txt"));
        }


        Assembly asm = Assembly.GetExecutingAssembly();

        public bool Test(string resourceName)
        {
            Utf8Checker checker = new Utf8Checker();
            using (Stream stream = asm.GetManifestResourceStream("Unicode.Tests.TestData." + resourceName))
            {
                return (checker .IsUtf8(stream));
            }
        }
    }
}
