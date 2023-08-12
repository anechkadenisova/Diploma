using Diploma.BussinesObject;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Diploma.Core;
using Diploma.PageStep;

namespace Diploma.PageStep
{
    public class Steps : BasePage
    {
        private By AdminPage = By.XPath("//span[text()='Admin']");
        private By JobsPage = By.XPath("//span[text()='Job ']");
        private By JobTitlesPage = By.XPath("//a[text()='Job Titles']");

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public Steps(IWebDriver webDriver) : base(webDriver)
        {

        }
        public override Steps OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep("Page Job Title")]
        public void JobTitle()
        {
            driver.FindElement(AdminPage).Click();
            driver.FindElement(JobsPage).Click();
            driver.FindElement(JobTitlesPage).Click();
        }

        public void GivenEnterUsername(IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUsername();
        }

    }
}