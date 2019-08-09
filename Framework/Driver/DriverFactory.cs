using Framework.BrowserSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Framework.Driver
{
    class DriverFactory
    {
        // factory for different drivers
        public IWebDriver GetDriver(ISettings settings)
        {
            switch (settings.Browser)
            {
                case "chrome":
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("--lang=en-GB");
                        options.AddArgument(@"--incognito");
                        options.AddArgument("--no-sandbox");
                        var Driver = new ChromeDriver(Environment.CurrentDirectory, options);
                        Driver.Manage().Window.Maximize();
                        return Driver;
                    }
                case "firefox":
                    {
                        var options = new FirefoxOptions();
                        //options.SetPreference("intl.accept_languages", "en"); <- TODO it is on changing language
                        //options.SetPreference("browser.privatebrowsing.autostart", true); <- TODO close inform message about private browsing
                        var Driver = new FirefoxDriver(Environment.CurrentDirectory, options);
                        Driver.Manage().Window.Maximize();
                        return Driver;
                    }
                default: return null;
            }
        }
    }
}
