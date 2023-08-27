using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace Diploma.Test
{
    [TestFixture]
   // [Parallelizable(ParallelScope.Fixtures)]
    internal class MyLeaveTest : BaseTest
    {
        [Test(Description = "Add comment in MyLeave page")]
        [AllureSeverity(Allure.Commons.SeverityLevel.minor)]
        [AllureSubSuite("MyLeave = Add Comments")]
        [AllureTms("TMS")]
        [AllureOwner("Anna Denisova")]
        [AllureIssue("Jira")]
        public void AnnMyLeaveList()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new MyLeavePage();
            page.LeaveNavigate();
            page.AddComments();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.successMessage));

        }

        [Test(Description = "Check comment in MyLeave page")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureSubSuite("MyLeave = Check Comment")]
        [AllureTms("TMS")]
        [AllureOwner("Anna Denisova")]
        [AllureIssue("Jira")]
        public void CheckComments()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new MyLeavePage();
            page.LeaveNavigate();
            page.CheckComment();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.okMessage));
        }
    }
}
