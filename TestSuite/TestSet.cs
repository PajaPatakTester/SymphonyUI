using System;
using Framework;
using NUnit.Framework;
using PageObjects;
using PageObjects.Models;

namespace TestSuite
{
    [TestFixture]
    public class TestSet : TestBase
    {
        private string _createEmail;
        private string _time;
        private string _dummyText;
        private string _dummyAddress;
        private StateEnum _stateEnum;
        private string _zipCode;
        private string _phoneNo;
        //bstest @test.com

        private HomePage _homePage;
        private AuthenticationPage _authPage;
        private CreateAnAccountForm _createAccountForm;
        private MyAccountPage _myAccountPage;

        public override void TestInitialization()
        {
            _time = DateTime.UtcNow.AddHours(2).ToString("dd/MM/yyyy_HH/mm/ss");
            _createEmail = $@"bstest_{_time}@test.com";
            _dummyText = "testText";
            _dummyAddress = "Washington Avenue 00, DC";
            _stateEnum = StateEnum.Alaska;
            _zipCode = "11000";
            _phoneNo = "555-6666666";

            _homePage = new HomePage();
            _authPage = new AuthenticationPage();
            _createAccountForm = new CreateAnAccountForm();
            _myAccountPage = new MyAccountPage();
        }

        [Test]
        public void VerifyCreationOfAnAccount()
        {
            _homePage.GoTo();
            _homePage.SignInClick();

            _authPage.CreateEmailAddressInput(_createEmail);
            _authPage.CreateAnAccountClick();

            _createAccountForm.FirstNameInput(_dummyText);
            _createAccountForm.LastNameInput(_dummyText);
            _createAccountForm.PasswordInput();
            _createAccountForm.AddressFirstNameInput(_dummyText);
            _createAccountForm.AddressLastNameInput(_dummyText);
            _createAccountForm.AddressInput(_dummyAddress);
            _createAccountForm.CityInput(_dummyText);
            _createAccountForm.SelectState(_stateEnum);
            _createAccountForm.ZipCodeInput(_zipCode);
            _createAccountForm.MobilePhoneInput(_phoneNo);
            _createAccountForm.RegisterClick();

            Assert.IsTrue(_myAccountPage.VerifySignoutDisplayed(), "Should be on My Account page.");

        }
    }
}
