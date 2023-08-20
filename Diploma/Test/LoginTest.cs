using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diploma.Test
{
    [TestFixture]
  //  [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTest : BaseTest
    {
        [Test]
        [AllureDescription("Authorization test")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureSubSuite("LoginPage = Authorization user")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void Login_StandartUser()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);


        }

        [Test]
        [AllureDescription("Authorization fail test with wrong user")]
        [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
        [AllureSubSuite("LoginPage = wrong authorization")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void LoginFailTest()
        {


            var user = UserBuilder.GetUnknownUser();
            Steps.Login(user);
            var page = new LoginPage();
            page.VerifyErrorMessage();
        }

    }
 }
