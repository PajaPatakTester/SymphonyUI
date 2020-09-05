using System;
using Framework;
using NUnit.Framework;
using PageObjects;

namespace TestSuite
{
    [TestFixture]
    public class TestSet : TestBase
    {
        private string _createEmail;
        private string _time;

        //bstest @test.com


        private HomePage _homePage;
        private AuthenticationPage _authPage;
        private CreateAnAccountForm _createAccountForm;

        public override void TestInitialization()
        {
            _time = DateTime.UtcNow.AddHours(2).ToString("dd/MM/yyyy_HH/mm/ss");
            _createEmail = $@"bstest_{_time}@test.com";
            _homePage = new HomePage();
            _authPage = new AuthenticationPage();
            _createAccountForm = new CreateAnAccountForm();
        }

        [Test]
        public void VerifyCreationOfAnAccount()
        {
            _homePage.GoTo();
            _homePage.SignInClick();
            _authPage.CreateEmailAddressInput(_createEmail);
            _authPage.CreateAnAccountClick();
        }
    }
}
