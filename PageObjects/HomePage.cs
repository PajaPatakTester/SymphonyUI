using Framework;
using OpenQA.Selenium;

namespace PageObjects
{
    public class HomePage
    {
        private const string HomeUrl = "http://automationpractice.com";
        private IWebElement SignInBtn() => WebDriver.Instance.FindElement(By.ClassName("login"));

        public void GoTo() => WebDriver.Instance.Navigate().GoToUrl(HomeUrl);

        public void SignInClick() => SignInBtn().Click();
    }
}
