﻿using OpenQA.Selenium;
using NUnit.Allure.Attributes;
using NLog;
using Diploma.Core;
using NLog.Targets;

namespace Diploma.BussinesObject
{
    internal class JobPage : BasePage
    {
        private By AdminPage = By.XPath("//span[text()='Admin']");
        private By JobsPage = By.XPath("//span[text()='Job ']");
        private By JobTitlesPage = By.XPath("//a[text()='Job Titles']");
        private By AddButton = By.CssSelector(".oxd-button--medium");
        private By SaveJob = By.CssSelector(".oxd-button--secondary");
        private By TitleJob = By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]");
        private By JobDescription = By.XPath("(//textarea[@placeholder='Type description here'])");
        private By Note = By.XPath("(//textarea[@placeholder='Add note'])");
        private By FieldAdmin = By.XPath("(//div[text()='Admin'])");
        private By EditIcon = By.XPath("(//i[@class='oxd-icon bi-pencil-fill'])[2]");
        private By DeleteIcon = By.XPath("(//i[@class='oxd-icon bi-trash'])[2]");
        private By DownloadFile = By.XPath("//input[@type='file']");
        private By DeletionConfirmation = By.CssSelector(".oxd-button--label-danger");
        private By ErrorMessage = By.CssSelector(".oxd-input-field-error-message");

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public JobPage()
        {

        }
        public override JobPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Page Job Title")]
        public void JobTitle()
        {
            logger.Info("Navigate to Job Page");
            driver.FindElement(AdminPage).Click();
            driver.FindElement(JobsPage).Click();
            driver.FindElement(JobTitlesPage).Click();
        }

        [AllureStep("Add new job")]
        public void AddNewJob()
    {
            logger.Info("Add new Job");
            driver.FindElement(AddButton).Click();
            driver.FindElement(TitleJob).SendKeys("Admin");
            driver.FindElement(JobDescription).SendKeys("test");
            driver.FindElement(Note).SendKeys("test");

            Thread.Sleep(2000);
            driver.FindElement(SaveJob).Click();
        }

        [AllureStep("Change new job")]
        public void ChangeNewJob()
        {
            logger.Info("Change new Job: Download File");
            Thread.Sleep(2000);
            IWebElement textElement = driver.FindElement(FieldAdmin);
            IWebElement editElement = textElement.FindElement(EditIcon);
            editElement.Click();

            IWebElement fileInput = driver.FindElement(DownloadFile);

            var path = Environment.CurrentDirectory;
            var filePath = "\\TestData\\AddDev.txt";
            var fullPath = path + filePath;

            fileInput.SendKeys(fullPath);

            Thread.Sleep(4000);
            driver.FindElement(SaveJob).Click();

        }

        [AllureStep("Delete new job")]
        public void DeleteNewJob()
        {
            logger.Info("Delete new Job");
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

            driver.FindElement(TitleJob).SendKeys("Finance Manager");

            driver.FindElement(SaveJob).Click();

            string ErrorMessageJob = driver.FindElement(ErrorMessage).Text;
            Thread.Sleep(2000);
            Assert.Fail(ErrorMessageJob);

            logger.Info("Verify error message when adding an existing title job");
            logger.Error("- error");
        }
    }
}
