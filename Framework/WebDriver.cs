using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace Framework
{
    public static class WebDriver
    {
        public static readonly TimeSpan ImplicitWaitTimeout = TimeSpan.FromSeconds(10);
        public static readonly TimeSpan PageLoad = TimeSpan.FromSeconds(20);
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance?.Quit();

            Instance = new ChromeDriver();

            // waits
            Instance.Manage().Timeouts().PageLoad = PageLoad;
            Instance.Manage().Timeouts().ImplicitWait = ImplicitWaitTimeout;

            try
            {
                Instance.Manage().Window.Maximize();
            }

            catch
            {
                // ignore error
            }
        }

        public static void Cleanup()
        {
            Instance?.Quit();
        }

        public static void Wait(double maxWaitSec, Func<bool> expression)
        {
            while (maxWaitSec > 0 && !expression())
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(300));
                maxWaitSec = -0.3;
            }
        }

        public static string TakeScreenshot(string testName)
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}", $"{testName}_{DateTime.UtcNow:yyyyMMMdd}.jpg");
                var screenShot = ((ITakesScreenshot)Instance).GetScreenshot();
                screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                return fileName;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to take screenschot: {e}");
                return null;
            }
        }
    }
}
