using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diploma.Test
{
    [TestFixture]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class JobTest : BaseTest
    {
        [Test(Description = "Add new job Admin")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSubSuite("JobTitle = Add Job")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void AddJob()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new JobPage();
            page.JobTitle();
            page.AddNewJob();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.successMessage));
        }

        [Test(Description = "Change job Admin - add file")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSubSuite("JobTitle = Change Job")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void ChangeJob()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new JobPage();
            page.JobTitle();
            page.ChangeNewJob();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.updateMessage));
        }

        [Test(Description = "Delete job Admin")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSubSuite("JobTitle = Delete Job")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void DeleteJob()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new JobPage();
            page.JobTitle();
            page.DeleteNewJob();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.deleteMessage));
        }

        [Test(Description = "Fail on repeating name of job")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSubSuite("JobTitle = fail")]
        [AllureOwner("Anna Denisova")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void RepeatJobFail()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new JobPage();
            page.JobTitle();
            page.AddHRJob();
        }
    }
}
