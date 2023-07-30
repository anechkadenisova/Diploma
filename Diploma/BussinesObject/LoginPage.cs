﻿using BasePageObjectModel;
using Diploma.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using OpenQA.Selenium;


namespace Diploma.BussinesObject
{
    internal class LoginPage : BasePage
    {
        private By UserNameInput = By.XPath("//input[@name='username']");
        private By PasswordInput = By.XPath("//input[@placeholder='password']");
        private By ErrorMessage = By.CssSelector(".oxd-alert-content-text");
        private By LoginButtton = By.CssSelector(".oxd-button");

        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public const string STANDART_USER_NAME = "Admin";
        public const string STANDART_PASSWORD = "admin123";

        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep("Enter user name")]
        public void EnterUsername()
        {
            var user = new UserModel()
            {
                Name = STANDART_USER_NAME,
                Password = STANDART_PASSWORD
            };
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
            logger.Warn($"- warn");
            logger.Debug($"- debug");
            logger.Error("- error");
            logger.Fatal(" - fatal");

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
