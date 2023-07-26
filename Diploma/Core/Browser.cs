using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Diploma.Core
{
    public class Browser
    {
        private static Browser instance = null;

        protected WebDriver driver;
        public WebDriver Driver { get { return driver; } }

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }

        private Browser()
        {
            var isHeadless = bool.Parse(TestContext.Parameters.Get("Headless"));
            var wait = int.Parse(TestContext.Parameters.Get("ImplicityWait"));

            if (isHeadless)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("incodnito");
                options.AddArgument("--start-maximized");

                driver = new ChromeDriver(options);
            }
            else
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }




    }
}
