using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using NUnit.Allure.Attributes;


namespace Diploma.Test
{
    public class JobTest : BaseTest
    {
        [Test(Description = "Add new job Admin")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSuite("Unit")]
        [AllureSubSuite("JobTitle = Add Job")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void AddJob()
        {
            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();

            var pageJob = new JobPage(driver);
            var pagestep = new Steps(driver);
            pagestep.JobTitle();
            pageJob.AddNewJob();

        }

        [Test(Description = "Change job Admin - add file")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSuite("Unit")]
        [AllureSubSuite("JobTitle = Change Job")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void ChangeJob()
        {
            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();
            var pageJob = new JobPage(driver);
            var pagestep = new Steps(driver);
            pagestep.JobTitle();
            pageJob.ChangeNewJob();
        }

        [Test(Description = "Delete job Admin")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSuite("Unit")]
        [AllureSubSuite("JobTitle = Delete Job")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void DeleteJob()
        {
            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();
            var pageJob = new JobPage(driver);
            var pagestep = new Steps(driver);
            pagestep.JobTitle();
            pageJob.DeleteNewJob();
        }

        [Test(Description = "Fail on repeating name of job")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSuite("Unit")]
        [AllureSubSuite("JobTitle = fail")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void RepeatJobFail()
        {
            Browser.Instance.NavigateToUrl("dfdf");
            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();

            var pageJob = new JobPage(driver);
            var pagestep = new Steps(driver);
            pagestep.JobTitle();
            pageJob.AddHRJob();
        }
    }
}
