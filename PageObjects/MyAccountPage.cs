using Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class MyAccountPage
    {
        #region Properties
        private IList<IWebElement> SignOutBtn() => WebDriver.Instance.FindElements(By.ClassName("logout"));

        #endregion

        #region Actions

        #endregion

        #region Verifications
        public bool VerifySignoutDisplayed() => SignOutBtn() != null && SignOutBtn().First().Displayed;
        #endregion
    }
}
