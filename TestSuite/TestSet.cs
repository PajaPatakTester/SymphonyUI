using System;
using Framework;
using NUnit.Framework;
using PageObjects;

namespace TestSuite
{
    [TestFixture]
    public class TestSet : TestBase
    {

        HomePage _homePage;
        public override void TestInitialization()
        {
            _homePage = new HomePage();
        }

        [Test]
        public void TestMethod1()
        {
            _homePage.GoTo();
        }
    }
}
