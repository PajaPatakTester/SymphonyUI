

using Framework;

namespace PageObjects
{
    public class HomePage 
    {
        private const string HomeUrl = "http://automationpractice.com";

        public void GoTo() => WebDriver.Instance.Navigate().GoToUrl(HomeUrl);
    }
}
