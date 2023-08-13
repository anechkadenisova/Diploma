using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Diploma.User;

namespace Diploma.BussinesObject
{
    public class LoginPage : BasePage
    {
        private By UserNameInput = By.XPath("//input[@name='username']");
        private By PasswordInput = By.XPath("//input[@placeholder='Password']");
        private By ErrorMessage = By.CssSelector(".oxd-alert-content-text");
        private By LoginButtton = By.CssSelector(".oxd-button");
        
        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";


        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public LoginPage()
        {

        }


        [AllureStep]
        public override LoginPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Enter user name")]
        public void EnterUsername()
        {
            logger.Info($"LoginAsStandartUser");

            var user = UserBuilder.GetStandartUser();
            TryToLogin(user);

        }

        [AllureStep("Enter user nameTry to  login")]
        public void TryToLogin(UserModel user)
        {
            logger.Info($"Try to login like user {user.ToString()}");
            driver.FindElement(UserNameInput).SendKeys(user.Name);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButtton).Click();
        }
       
        [AllureStep("Authorisation Error")]
        public void VerifyErrorMessage()
        {

            logger.Info("Verify error message for incorrect data for login");
            logger.Error("- error");


            try
            {
                WebElement errormessage = (WebElement)driver.FindElement(ErrorMessage);

                Assert.Fail("Error autorization: "+errormessage.Text);
            }
            catch (NoSuchElementException)
            {
                Assert.Pass("Successful authorization");
            }
        }


    }
}
