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
        private int _bestSellers;
        private int _popular;
        private string _printedDresses;
        private string[] _dresses;
        private string[] _negativeDresses;

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
            _bestSellers = 7;
            _popular = 7;
            _printedDresses = "Printed dresses";
            _dresses = new[] { "Printed Summer Dress", "Printed Dress", "Printed Chiffon Dress", "Printed Summer Dress", "Printed Dress" };
            _negativeDresses = new[] { "AAAAPrinted Summer Dress", "Printed Dress", "Printed Chiffon Dress", "Printed Summer Dress", "Printed Dress" };

            _homePage = new HomePage();
            _authPage = new AuthenticationPage();
            _createAccountForm = new CreateAnAccountForm();
            _myAccountPage = new MyAccountPage();
        }

        [Test]
        public void TC01_VerifyCreationOfAnAccount()
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

            Assert.IsTrue(_myAccountPage.VerifySignoutDisplayed(), "Should be on My Account page but it is not the case.");
        }

        [Test]
        public void TC02_VerifyNumberOfDisplayedProductsOnHomePage()
        {
            _homePage.GoTo();

            Assert.IsTrue(_homePage.VerifyNumberOfDisplayedPopularProducts(_popular), $@"Page should show {_popular} popular products but it is not.");

            _homePage.BestSellersClick();

            Assert.IsTrue(_homePage.VerifyNumberOfDisplayedBestSellersProducts(_bestSellers), $@"Page should show {_bestSellers} Best Sellers products but it is not.");
        }

        [Test]
        public void TC03_CreateFilePrintedDressesNames()
        {
            _homePage.GoTo();
            _homePage.SearchForProduct(_printedDresses);

            _homePage.FileWithProductNames();

            Assert.IsTrue(_homePage.VerifyProductNamesWriten(_dresses), "Dresses should be printed into file Documents/ProductNames.txt but it is not. See consol log for more details.");
        }

        // Test that will fail because expected that dress has name "AAAAPrinted Summer Dress" instead of "Printed Summer Dress"
        [Test]
        public void TC04_NEGATIVETest_CreateFilePrintedDressesNames()
        {
            _homePage.GoTo();
            _homePage.SearchForProduct(_printedDresses);

            _homePage.FileWithProductNames();

            Assert.IsTrue(_homePage.VerifyProductNamesWriten(_negativeDresses), "Dresses should be printed into file Documents/ProductNames.txt but it is not. See consol log for more details.");
        }
    }
}
