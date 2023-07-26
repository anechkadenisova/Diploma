using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace Diploma.BussinesObject
{
    internal class JobPage : BasePage
    {
        private By Admin = By.XPath("//span[text()='Admin']");
        private By Jobs = By.XPath("//span[text()='Job ']");
        private By JobTitles = By.XPath("//a[text()='Job Titles']");
        private By AddButton = By.CssSelector(".oxd-button--medium");
        private By DownloadFile = By.CssSelector(".oxd-file-button");
        private By SaveJob = By.CssSelector(".oxd-button--secondary");



        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";


        public JobPage(WebDriver webDriver) : base(webDriver)
        {

        }
        public override JobPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep("Page Job Title")]
        public void JobTitle()
        {
            driver.FindElement(Admin).Click();
            driver.FindElement(Jobs).Click();
            driver.FindElement(JobTitles).Click();
        }

        [AllureStep]
        public void AddNewJob()
    { 
            driver.FindElement(AddButton).Click();

            driver.FindElement(By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]")).SendKeys("Admin");
            driver.FindElement(By.XPath("(//textarea[@placeholder='Type description here'])")).SendKeys("test");


            driver.FindElement(By.XPath("(//textarea[@placeholder='Add note'])")).SendKeys("test");

            Thread.Sleep(2000);
            driver.FindElement(SaveJob).Click();
        }

        [AllureStep]
        public void ChangeNewJob()
        {
            Thread.Sleep(2000);
            IWebElement textElement = driver.FindElement(By.XPath("(//div[text()='Admin'])"));
            IWebElement editElement = textElement.FindElement(By.XPath("(//i[@class='oxd-icon bi-pencil-fill'])[2]"));
            editElement.Click();

            IWebElement fileInput = driver.FindElement(By.XPath("//input[@type='file']"));

            var path = Environment.CurrentDirectory;
            var filePath = "\\TestData\\AddDev.txt";
            var fullPath = path + filePath;

            fileInput.SendKeys(fullPath);

            Thread.Sleep(2000);
            driver.FindElement(SaveJob).Click();

        }

        [AllureStep]
        public void DeleteNewJob()
        {
            Thread.Sleep(2000);
            IWebElement textElement = driver.FindElement(By.XPath("(//div[text()='Admin'])"));
            IWebElement delElement = textElement.FindElement(By.XPath("(//i[@class='oxd-icon bi-trash'])[2]"));
            delElement.Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".oxd-button--label-danger")).Click();


        }

        [AllureStep]
        public void AddHRJob()
        {
            driver.FindElement(AddButton).Click();

            driver.FindElement(By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]")).SendKeys("Finance Manager");

            driver.FindElement(SaveJob).Click();

            string ErrorMessageJob = driver.FindElement(By.CssSelector(".oxd-input-field-error-message")).Text;
            string errorMessage = "Already exists";
            Thread.Sleep(2000);
            Assert.AreEqual(ErrorMessageJob, errorMessage);
        }
    }
}
