using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Framework.Driver
{
    class DriverFactory
    {
        // factory for different drivers
        public IWebDriver GetDriver(string DesiredDriver)
        {
            switch (DesiredDriver)
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
                default: return null;
            }
        }
    }
}
