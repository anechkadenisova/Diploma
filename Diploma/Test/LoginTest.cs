using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diploma.Test
{
    public class LoginTest : BaseTest
    {
        [Test]
        [AllureDescription("Authorization test")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureSuite("Unit")]
        [AllureSubSuite("LoginPage = Authorization user")]
        public void Login_StandartUser()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);


        }

        [Test]
        [AllureDescription("Authorization fail test with wrong user")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureSuite("Unit")]
        [AllureSubSuite("LoginPage = wrong authorization")]
        public void LoginFailTest()
        {


            var user = UserBuilder.GetUnknownUser();
            Steps.Login(user);
            var page = new LoginPage();
            page.VerifyErrorMessage();
        }

    }
 }
