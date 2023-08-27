using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework;


namespace Diploma.Core
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        private AllureLifecycle allure;

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

            Browser.Instance.Driver.Quit();
            Browser.Instance.CloseBrowser();
        }
    }
}
