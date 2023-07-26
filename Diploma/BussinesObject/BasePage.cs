using OpenQA.Selenium;



namespace Diploma.BussinesObject
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public abstract BasePage OpenPage();
    }
}
