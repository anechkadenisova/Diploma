using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace Diploma.Test
{
    internal class EntitlementTest : BaseTest
    {
        [Test(Description = "Add Leave Entitlement with Multiple Employees")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSubSuite("Entitlement = Add Leave Entitlement")]
        [AllureTms("TMS")]
        [AllureOwner("Anna Denisova")]
        [AllureIssue("Jira")]
        public void AddLeaveEntitlement()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new EntitlementPage();
            page.LeaveNavigateDashboard();
            page.AddedEntitlement();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.leavePage));
        }
    }
}