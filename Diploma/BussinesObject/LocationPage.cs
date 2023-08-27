using Diploma.Core;
using Diploma.Helpers;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BussinesObject
{
    public class LocationPage : BasePage
    {
        private By AdminPage = By.XPath("//span[text()='Admin']");
        private By OrganizationTitle = By.XPath("//span[text()='Organization ']");
        private By LocationTitlesPage = By.XPath("//a[text()='Locations']");
        private By AddButton = By.CssSelector(".oxd-button-icon");
        private By SaveLocation = By.CssSelector(".oxd-button--secondary");
        private By NameLocation = By.XPath("(//input[@class='oxd-input oxd-input--active'])[2]");
        private By City = By.XPath("(//input[@class='oxd-input oxd-input--active'])[3]");
        private By ZipCode = By.XPath("(//input[@class='oxd-input oxd-input--active'])[5]");
        private By LocationDropdown = By.XPath("//label[text()='Country']/following::div[@class='oxd-select-text-input']");
        private By LocationText = By.XPath("//*[text()='Brazil']");
        private By SucceessMessage = By.XPath("//p[text()='Successfully Saved']");
        private By IconPencil = By.CssSelector(".bi-pencil-fill");
        private By IconDelete = By.CssSelector(".oxd-table-cell-action-space");
        private By DeletionConfirmation = By.CssSelector(".oxd-button--label-danger");
        private By DeleteMessage = By.XPath("//p[text()='Successfully Deleted']");

        public By successMessage => SucceessMessage;
        public By iconPencil => IconPencil;
        public By deleteMessage => DeleteMessage;

        public string url = TestContext.Parameters.Get("Url");

        public static Logger logger = LogManager.GetCurrentClassLogger();

        public LocationPage()
        {
        }
        public override LocationPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Page  Location Title")]
        public void LocationTitle()
        {
            logger.Info("Navigate to Job Page");
            driver.FindElement(AdminPage).Click();
            driver.FindElement(OrganizationTitle).Click();
            driver.FindElement(LocationTitlesPage).Click();
        }

        [AllureStep("Add new location")]
        public void AddNewLocation()
        {
            var name = RandomHelper.GenerateRandomString(7);
            var code = RandomHelper.GenerateRandomNumericString(6);

            logger.Info("Add new Location");
            driver.FindElement(AddButton).Click();
            driver.FindElement(NameLocation).SendKeys(name);
            driver.FindElement(City).SendKeys(name);
            driver.FindElement(ZipCode).SendKeys(code);

            IWebElement locationDropdown = driver.FindElement(LocationDropdown);
            locationDropdown.Click();
            IWebElement locationText = driver.FindElement(LocationText);
            locationText.Click();

            driver.FindElement(SaveLocation).Click();
        }

        [AllureStep("Check new location")]
        public void CheckNewLocation()
        {
            logger.Info("Check new Location");

            IWebElement locationDropdown = driver.FindElement(LocationDropdown);
            locationDropdown.Click();
            IWebElement locationText = driver.FindElement(LocationText);
            locationText.Click();
            driver.FindElement(SaveLocation).Click();
        }

        [AllureStep("Delete new location")]
        public void DeleteNewLocation()
        {
            logger.Info("Delete new Location");

            driver.FindElement(IconDelete).Click();
            driver.FindElement(DeletionConfirmation).Click();
        }
    }
}