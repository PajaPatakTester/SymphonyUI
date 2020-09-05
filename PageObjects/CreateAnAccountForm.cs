using Framework;
using OpenQA.Selenium;

namespace PageObjects
{
   public class CreateAnAccountForm
    {
        private IWebElement SignInBtn() => WebDriver.Instance.FindElement(By.Id("email_create"));
        private IWebElement CreateAnAccountBtn() => WebDriver.Instance.FindElement(By.Id("SubmitCreate"));
    }
}
