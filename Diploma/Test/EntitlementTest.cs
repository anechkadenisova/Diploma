using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void addLeaveEntitlement()
        {

            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new EntitlementPage();
            page.LeaveNavigateDashboard();
            page.AddedEntitlement();


        }
}
}
