using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Test
{
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
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//p[text()='Successfully Saved']")));


        }

        [Test(Description = "Check comment in MyLeave page")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureSubSuite("MyLeave = Check Comment")]
        [AllureTms("TMS")]
        [AllureOwner("Anna Denisova")]
        [AllureIssue("Jira")]
        public void ChechComments()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new MyLeavePage();
            page.LeaveNavigate();
            page.CheckComment();

        }
        
    }
}
