using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Framework
{
    public static class FindElementNoWaitExtension
    {
        public static IWebElement FindElementNoWait(this IWebDriver webDriver, By by)
        {
            //  turn off implicit wait
            WebDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            IWebElement result = null;
            try
            {
                result = WebDriver.Instance.FindElement(by);
            }
            catch (Exception)
            {
                //  ignored
            }

            //  turn on implicit wait (back on)
            WebDriver.Instance.Manage().Timeouts().ImplicitWait = WebDriver.ImplicitWaitTimeout;

            return result;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsNoWait(this IWebDriver webDriver, By by)
        {
            //  turn off implicit wait
            WebDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            var result = WebDriver.Instance.FindElements(by);

            //  turn on implicit wait (back on)
            WebDriver.Instance.Manage().Timeouts().ImplicitWait = WebDriver.ImplicitWaitTimeout;

            return result;
        }

    }
}