using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Framework
{
    public abstract class TestBase
    {
        private Stopwatch _stopwatch = new Stopwatch();


        [SetUp]
        public void Init()
        {
            _stopwatch.Restart();
            WebDriver.Initialize();
            TestInitialization();
        }


        [TearDown]
        public void Cleanup()
        {
            _stopwatch.Stop();

        
            if (!TestCompletedWithoutErrors())
            {
                TakeScreenshot();
                ErrorCleanup();
            }

            else
            {
                TestCleanup();
            }

            WebDriver.Cleanup();
        }

        public abstract void TestInitialization();

        protected virtual void TestCleanup() { }

        protected virtual void ErrorCleanup() { }


        private void TakeScreenshot()
        {
            var screenshot = WebDriver.TakeScreenshot(TestContext.CurrentContext.Test.Name);
            if (screenshot != null) TestContext.AddTestAttachment(screenshot);
        }

        public bool TestCompletedWithoutErrors()
        {
            return TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive) ||
                   TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        }
    }
}
