using OpenQA.Selenium;



namespace Diploma.BussinesObject
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public abstract BasePage OpenPage();
    }
}
