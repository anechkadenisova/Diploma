using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Diploma.Core;
using OpenQA.Selenium.Interactions;

namespace Diploma.Core
{
          public class Browser
        {
            private static Browser? instance;

            protected IWebDriver driver;
            public IWebDriver Driver { get { return driver; } }

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
                driver.Navigate().GoToUrl(url);
            }


            public void CloseBrowser()
            {
                driver?.Dispose();
                instance = null;
            }

        }
    }
