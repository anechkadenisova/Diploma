using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BussinesObject
{
    internal class EntitlementPage : BasePage

    {
        private By Dashboard = By.XPath("//span[text()='Dashboard']");
        private By LeaveList = By.XPath("(//button[@class='oxd-icon-button orangehrm-quick-launch-icon'])[2]");
        private By Entitlements = By.XPath("//span[text()='Entitlements ']");
        private By AddEntitlements = By.XPath("//a[text()='Add Entitlements']");
        private By MultipleEmployees = By.XPath("//label[text()='Multiple Employees']");
        private By LocationDropdown = By.XPath("//label[text()='Location']/following::div[@class='oxd-select-text-input']");
        private By SubUnitDropdown = By.XPath("//label[text()='Sub Unit']/following::div[@class='oxd-select-text-input']");
        private By LeaveTypeDropdown = By.XPath("//label[text()='Leave Type']/following::div[@class='oxd-select-text-input']");
        private By Entitlement = By.XPath("//label[text()='Entitlement']/following::input[@class='oxd-input oxd-input--active']");
        private By Submit = By.XPath("(//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space'])[1]");
        private By UpdatingSubmit = By.XPath("(//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space'])[2]");


        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public static Logger logger = LogManager.GetCurrentClassLogger();

        public EntitlementPage()
        {

        }
        public override EntitlementPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        [AllureStep("Navigate to Dashboard: Leave List")]
        public void LeaveNavigateDashboard()
        {
            logger.Info("Navigate to Leave List with Quick Launch");
            driver.FindElement(LeaveList).Click();
        }

        [AllureStep("Add new entitlement")]
        public void AddedEntitlement()
        {
            logger.Info("Add new entitlement: Multiple Employees");
            driver.FindElement(Entitlements).Click();
            driver.FindElement(AddEntitlements).Click();
            driver.FindElement(MultipleEmployees).Click();;
            IWebElement locationDropdown = driver.FindElement(LocationDropdown);
            locationDropdown.Click();
            IWebElement locationText = driver.FindElement(By.XPath("//*[text()='Texas R&D']"));
            locationText.Click();

            IWebElement subUnitDropdown = driver.FindElement(SubUnitDropdown);
            subUnitDropdown.Click();
            IWebElement subUnitText = driver.FindElement(By.XPath("//*[text()='Engineering']"));
            subUnitText.Click();


            IWebElement leaveTypeDropdown = driver.FindElement(LeaveTypeDropdown);
            leaveTypeDropdown.Click();
            IWebElement leaveTypeText = driver.FindElement(By.XPath("//*[text()='US - Personal']"));
            leaveTypeText.Click();

            IWebElement entitlement = driver.FindElement(Entitlement);
            entitlement.Click();
            entitlement.SendKeys("14");

            IWebElement submit = driver.FindElement(Submit);
            submit.Click();

            IWebElement updatingSubmit = driver.FindElement(UpdatingSubmit);
            updatingSubmit.Click();
        }
    }
}
