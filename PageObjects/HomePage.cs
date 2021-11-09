using Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace PageObjects
{
    public class HomePage
    {
        #region Properties
        private const string HomeUrl = "http://automationpractice.com";
        private static readonly string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static readonly string DocumentsFolderPath = Path.Combine(UserPath, "Documents");
        private IWebElement SignInBtn() => WebDriver.Instance.FindElement(By.ClassName("login"));
        private IWebElement PopularBtn() => WebDriver.Instance.FindElement(By.ClassName("homefeatured"));
        private IWebElement BestSellersBtn() => WebDriver.Instance.FindElement(By.ClassName("blockbestsellers"));
        private IList<IWebElement> TotalPopularProducts() => WebDriver.Instance.FindElements(By.CssSelector("#homefeatured li i"));
        private IList<IWebElement> TotalBestSellersProducts() => WebDriver.Instance.FindElements(By.CssSelector("#blockbestsellers li i"));
        private IList<IWebElement> DisplayedPopularProducts() => WebDriver.Instance.FindElements(By.CssSelector("#homefeatured.active li i"));
        private IList<IWebElement> DisplayedBestSellersProducts() => WebDriver.Instance.FindElements(By.CssSelector("#blockbestsellers.active li i"));
        private IWebElement SearchField() => WebDriver.Instance.FindElement(By.Id("search_query_top"));

        #endregion

        #region Actions
        public void GoTo() => WebDriver.Instance.Navigate().GoToUrl(HomeUrl);

        public void SignInClick() => SignInBtn().Click();
        public void BestSellersClick() => BestSellersBtn().Click();
        public void PopularClick() => PopularBtn().Click();
        public void SearchForProduct(string name)
        {
            SearchField().SendKeys(name);
            SearchField().SendKeys(Keys.Enter);
            WebDriver.Wait(5, () => WebDriver.Instance.FindElement(By.TagName("h1")).Text.Contains("Search"));
            WebDriver.WaitForAjax();
            // Due to luck of time, this will be handled with implicit wait, even this is bad practice
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        public void FileWithProductNames()
        {
            // FYI: File is located in //Documents/ProductNames.txt
            var displayedProductNames = WebDriver.Instance.FindElements(By.CssSelector(".product_list .product-name"));

            using (StreamWriter writetext = new StreamWriter(DocumentsFolderPath + "/ProductNames.txt"))

                foreach (var prod in displayedProductNames)
                {
                    writetext.WriteLine(prod.Text);
                }
        }
        #endregion

        #region Verification
        public bool VerifyNumberOfDisplayedPopularProducts(int expected) => DisplayedPopularProducts().Count == expected;
        public bool VerifyNumberOfDisplayedBestSellersProducts(int expected) => DisplayedBestSellersProducts().Count == expected;

        public bool VerifyProductNamesWriten(string[] names)
        {
            var readText = "";
            using (StreamReader readtext = new StreamReader(DocumentsFolderPath + "/ProductNames.txt"))
            {
                readText = readtext.ReadToEnd();
            };

            foreach (var prod in names)
            {
                if (!readText.Contains(prod))
                {
                    Console.WriteLine($@"Dress with name: {prod} was not found in the file.");
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
