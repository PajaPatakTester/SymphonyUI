using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjects.Models;
using System;

namespace PageObjects
{
    public class CreateAnAccountForm
    {
        private const string Password = "testPassword123!!!";

        #region Properties
        private IWebElement FirstNameField() => WebDriver.Instance.FindElement(By.Id("customer_firstname"));
        private IWebElement LastNameField() => WebDriver.Instance.FindElement(By.Id("customer_lastname"));
        private IWebElement PasswordField() => WebDriver.Instance.FindElement(By.Id("passwd"));
        private IWebElement AddressFirstNameField() => WebDriver.Instance.FindElement(By.Id("firstname"));
        private IWebElement AddressLastNameField() => WebDriver.Instance.FindElement(By.Id("customer_lastname"));
        private IWebElement AddressField() => WebDriver.Instance.FindElement(By.Id("address1"));
        private IWebElement CityField() => WebDriver.Instance.FindElement(By.Id("city"));
        private IWebElement ZipCodeField() => WebDriver.Instance.FindElement(By.Id("postcode"));
        private IWebElement MobilePhoneField() => WebDriver.Instance.FindElement(By.Id("phone_mobile"));
        private IWebElement AliasField() => WebDriver.Instance.FindElement(By.Id("alias"));
        private IWebElement RegisterBtn() => WebDriver.Instance.FindElement(By.Id("submitAccount"));
        #endregion

        #region Actions
        public void FirstNameInput(string name) => FirstNameField().SendKeys(name);
        public void LastNameInput(string name) => LastNameField().SendKeys(name);
        public void PasswordInput() => PasswordField().SendKeys(Password);

        public void AddressFirstNameInput(string name) => AddressFirstNameField().SendKeys(name);
        public void AddressLastNameInput(string name) => AddressLastNameField().SendKeys(name);
        public void AddressInput(string address) => AddressField().SendKeys(address);
        public void CityInput(string city) => CityField().SendKeys(city);
        public void SelectState(StateEnum state)
        {
            // Wait for selector to load elements
            WebDriver.Wait(5, () => WebDriver.Instance.FindElementsNoWait(By.CssSelector("#id_state option")).Count >= 2);

            var selectElement = new SelectElement(WebDriver.Instance.FindElement(By.Id("id_state")));
            selectElement.SelectByIndex((int)state);
        }
        public void ZipCodeInput(string zip) => ZipCodeField().SendKeys(zip);
        public void MobilePhoneInput(string phone) => MobilePhoneField().SendKeys(phone);
        public void AliasInput(string alias) => AliasField().SendKeys(alias);

        public void RegisterClick() {
            WebDriver.Wait(10, () => WebDriver.Instance.FindElementsNoWait(By.ClassName(".form-ok")).Count >=3);
            RegisterBtn().Click();
        }
        #endregion

    }
}
