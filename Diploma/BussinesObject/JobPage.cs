using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace Diploma.BussinesObject
{
    internal class JobPage : BasePage
    {

        private By AddButton = By.CssSelector(".oxd-button--medium");
        private By SaveJob = By.CssSelector(".oxd-button--secondary");
        private By JobTitle = By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]");
        private By JobDescription = By.XPath("(//textarea[@placeholder='Type description here'])");
        private By Note = By.XPath("(//textarea[@placeholder='Add note'])");
        private By FieldAdmin = By.XPath("(//div[text()='Admin'])");
        private By EditIcon = By.XPath("(//i[@class='oxd-icon bi-pencil-fill'])[2]");
        private By DeleteIcon = By.XPath("(//i[@class='oxd-icon bi-trash'])[2]");
        private By DownloadFile = By.XPath("//input[@type='file']");
        private By DeletionConfirmation = By.CssSelector(".oxd-button--label-danger");
        private By ErrorMessage = By.CssSelector(".oxd-input-field-error-message");

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public JobPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public override JobPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }


        [AllureStep("Add new job")]
        public void AddNewJob()
    { 
            driver.FindElement(AddButton).Click();

            driver.FindElement(JobTitle).SendKeys("Admin");
            driver.FindElement(JobDescription).SendKeys("test");
            driver.FindElement(Note).SendKeys("test");

            Thread.Sleep(2000);
            driver.FindElement(SaveJob).Click();
        }

        [AllureStep("Change new job")]
        public void ChangeNewJob()
        {
            Thread.Sleep(2000);
            IWebElement textElement = driver.FindElement(FieldAdmin);
            IWebElement editElement = textElement.FindElement(EditIcon);
            editElement.Click();

            IWebElement fileInput = driver.FindElement(DownloadFile);

            var path = Environment.CurrentDirectory;
            var filePath = "\\TestData\\AddDev.txt";
            var fullPath = path + filePath;

            fileInput.SendKeys(fullPath);

            Thread.Sleep(2000);
            driver.FindElement(SaveJob).Click();

        }

        [AllureStep("Delete new job")]
        public void DeleteNewJob()
        {
            Thread.Sleep(2000);
            IWebElement textElement = driver.FindElement(FieldAdmin);
            IWebElement delElement = textElement.FindElement(DeleteIcon);
            delElement.Click();
            Thread.Sleep(1000);
            driver.FindElement(DeletionConfirmation).Click();
        }

        [AllureStep("Error checking for an existing name job")]
        public void AddHRJob()
        {
            driver.FindElement(AddButton).Click();

            driver.FindElement(JobTitle).SendKeys("Finance Manager");

            driver.FindElement(SaveJob).Click();

            string ErrorMessageJob = driver.FindElement(ErrorMessage).Text;
            string errorMessage = "Already exists";
            Thread.Sleep(2000);
            //Assert Fail?
            Assert.AreEqual(ErrorMessageJob, errorMessage);
        }
    }
}
