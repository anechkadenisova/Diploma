using Diploma.BussinesObject;
using Diploma.Core;
using NUnit.Allure.Attributes;


namespace Diploma.Test
{
    public class JobTest : BaseTest
    {
        [Test]
        public void AddAndDeleteJob()
        {
            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();


            var pageJob = new JobPage(driver);
            pageJob.JobTitle();
            pageJob.AddNewJob();
            pageJob.ChangeNewJob();
            pageJob.DeleteNewJob();

        }

        [Test(Description = "Fail on repeating name of job")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureSuite("Job")]
        [AllureSubSuite("JobTitle = fail")]
        [AllureTms("TMS")]
        [AllureIssue("Jira")]
        public void RepeatJobFail()
        {

            var page = new LoginPage(driver);
            page.OpenPage();
            page.EnterUsername();

            var pageJob = new JobPage(driver);
            pageJob.JobTitle();
            pageJob.AddHRJob();
        }
    }
}
