using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diploma.BussinesObject
{
    internal class MyLeavePage : BasePage
    {
        private By LeaveMenu = By.XPath("//span[text()='Leave']");
        private By MyLeave = By.XPath("//a[text()='My Leave']");
        private By ThreeDots = By.CssSelector(".bi-three-dots-vertical");
        private By AddComment = By.CssSelector(".oxd-table-dropdown-item");
        private By TitleComment = By.CssSelector(".oxd-textarea");
        private By SaveButton = By.XPath("//button[text()=' Save ']");
        private By LaveDetails = By.XPath("//p[text()='View Leave Details']");
        private By CommentsButton = By.CssSelector(".oxd-button--secondary");
        private By SucceessMessage = By.XPath("//p[text()='Successfully Saved']");
        private By OkMessage= By.XPath("//p[text()='OK']");

        public By successMessage => SucceessMessage;
        public By okMessage => OkMessage;

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public static Logger logger = LogManager.GetCurrentClassLogger();

        public MyLeavePage()
        {
        }
        public override MyLeavePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        [AllureStep("Navigate to MyLeave List")]
        public void LeaveNavigate()
        {
            logger.Info("Navigate to Leave List with Quick Launch");
            driver.FindElement(LeaveMenu).Click();
            driver.FindElement(MyLeave).Click();
        }

        [AllureStep("Add comment in MyLeave")]
        public void AddComments()
        {
            logger.Info("Add new comment in Leave List: OK");
            driver.FindElement(ThreeDots).Click();
            Thread.Sleep(2000);
            driver.FindElement(AddComment).Click();
            driver.FindElement(TitleComment).SendKeys("OK");
            Thread.Sleep(1000);
            driver.FindElement(SaveButton).Click();
        }

        [AllureStep("Chech comment in MyLeave List: OK")]
        public void CheckComment()
        {
            logger.Info("Chech comment in Leave List");
            driver.FindElement(ThreeDots).Click();
            driver.FindElement(LaveDetails).Click();
            driver.FindElement(CommentsButton).Click();
        }
    }
}
