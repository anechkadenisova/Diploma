using Allure.Commons;
using Diploma.BussinesObject;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Diploma.Core
{
    [AllureNUnit]
    public class BaseTest
    {
        private AllureLifecycle allure;
        protected WebDriver driver = Browser.Instance.Driver;
        private LoginPage loginPage;
        private JobPage jobPage;

        [SetUp]

        public void SetUp()
        {
            allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                allure.AddAttachment("Screenshot", "image/png", bytes);
            }
            driver.Quit();
        }
    }
}
