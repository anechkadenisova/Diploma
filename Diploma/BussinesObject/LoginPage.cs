using BasePageObjectModel;
using Diploma.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using OpenQA.Selenium;



namespace Diploma.BussinesObject
{
    internal class LoginPage : BasePage
    {
        private By UserNameInput = By.XPath("//input[@name='username']");
        private By PasswordInput = By.XPath("//input[@placeholder='Password']");
        private By ErrorMessage = By.CssSelector(".oxd-alert-content-text");
        private By LoginButtton = By.CssSelector(".oxd-button");

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public const string STANDART_USER_NAME = "Admin";
        public const string STANDART_PASSWORD = "admin123";

        public LoginPage(WebDriver webDriver) : base(webDriver)
        {

        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep]
        public void EnterUsername()
        {
            var user = new UserModel()
            {
                Name = STANDART_USER_NAME,
                Password = STANDART_PASSWORD
            };
            TryToLogin(user);
        }

        [AllureStep]
        public void TryToLogin(UserModel user)
        {
            driver.FindElement(UserNameInput).SendKeys(user.Name);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButtton).Click();
        }
        [AllureStep]
        public void VerifyErrorMessage()
        {
            try
            {
                WebElement errormessage = (WebElement)driver.FindElement(ErrorMessage);

                Assert.Fail("Error autorization: "+errormessage.Text);
            }
            catch (NoSuchElementException)
            {
                Assert.Pass("Good");
            }
        }


    }
}
