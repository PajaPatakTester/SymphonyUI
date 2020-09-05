using Framework;
using OpenQA.Selenium;

namespace PageObjects
{
    public class AuthenticationPage
    {

        #region Properties
        private const string Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

        // Create an account
        private IWebElement CreateEmailField() => WebDriver.Instance.FindElement(By.Id("email_create"));
        private IWebElement CreateAnAccountBtn() => WebDriver.Instance.FindElement(By.Id("SubmitCreate"));

        // Sign in
        private IWebElement SignInEmailField() => WebDriver.Instance.FindElement(By.Id("email"));
        private IWebElement SignInPassField() => WebDriver.Instance.FindElement(By.Id("passwd"));
        private IWebElement SignInBtn() => WebDriver.Instance.FindElement(By.Id("SubmitLogin"));
        #endregion

        #region Actions

        public void GoTo() => WebDriver.Instance.Navigate().GoToUrl(Url);

        // Create an account
        public void CreateEmailAddressInput(string email) => CreateEmailField().SendKeys(email);
        public void CreateAnAccountClick() => CreateAnAccountBtn().Click();
        #endregion
    }
}
