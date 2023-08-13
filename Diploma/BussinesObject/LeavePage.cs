using Diploma.Core;
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
    internal class LeavePage : BasePage

    {
        private By Dashboard = By.XPath("//span[text()='Dashboard']");
        private By LeaveList = By.XPath("//p[text()='Leave List']");


        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public LeavePage()
        {

        }
        public override LeavePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        [AllureStep("Navigate to Dashboard: Leave List")]
        public void LeaveNavigate()
        {
            logger.Info("Navigate to Dashboard: Leave List with Quick Launch");
            driver.FindElement(Dashboard).Click();
            driver.FindElement(LeaveList).Click();
        }
    }
}
