using Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PageObjects
{
    public class HomePage
    {
        #region Properties
        private const string HomeUrl = "http://automationpractice.com";
        private IWebElement SignInBtn() => WebDriver.Instance.FindElement(By.ClassName("login"));
        private IWebElement PopularBtn() => WebDriver.Instance.FindElement(By.ClassName("homefeatured"));
        private IWebElement BestSellersBtn() => WebDriver.Instance.FindElement(By.ClassName("blockbestsellers"));
        private IList<IWebElement> TotalPopularProducts() => WebDriver.Instance.FindElements(By.CssSelector("#homefeatured li i"));
        private IList<IWebElement> TotalBestSellersProducts() => WebDriver.Instance.FindElements(By.CssSelector("#blockbestsellers li i"));
        private IList<IWebElement> DisplayedPopularProducts() => WebDriver.Instance.FindElements(By.CssSelector("#homefeatured.active li i"));
        private IList<IWebElement> DisplayedBestSellersProducts() => WebDriver.Instance.FindElements(By.CssSelector("#blockbestsellers.active li i"));

        #endregion

        #region Actions
        public void GoTo() => WebDriver.Instance.Navigate().GoToUrl(HomeUrl);

        public void SignInClick() => SignInBtn().Click();
        public void BestSellersClick() => BestSellersBtn().Click();
        #endregion

        #region Verification
        public bool VerifyNumberOfDisplayedPopularProducts(int expected) => DisplayedPopularProducts().Count == expected;
        public bool VerifyNumberOfDisplayedBestSellersProducts(int expected) => DisplayedBestSellersProducts().Count == expected;

        #endregion

    }
}
