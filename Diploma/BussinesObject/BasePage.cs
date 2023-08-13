using OpenQA.Selenium;
using Diploma.Core;


namespace Diploma.BussinesObject
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();
    }
}
