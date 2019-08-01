﻿using Framework.BrowserSettings;
using Framework.Waiter;
using Framework.WebElements;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using LogLevel = NLog.LogLevel;

namespace Framework.Driver
{
    public class BaseDriver
    {
        public IWebDriver IWebDriver { get; private set; }
        public WebWaiter WebWaiter { get; private set; }
        public Actions Actions { get; private set; }
        public Logger Logger { get; private set; }
        public ISettings Settings { get; private set; }

        public BaseDriver() : this(new Settings()) { }

        public BaseDriver(ISettings settings)
        {
            Settings = settings;
            IWebDriver = new DriverFactory().GetDriver(Settings.Browser);
            WebWaiter = new WebWaiter(new WebDriverWait(IWebDriver, Settings.TimeWait));
            Actions = new Actions(IWebDriver);
            Logger = LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            LogManager.Configuration = config;
        }


        public void NavigateTo(string url) => IWebDriver.Navigate().GoToUrl(url);

        public string GetTitle() => IWebDriver.Title;

        public RetryingElementLocator RetryingElementLocator => new RetryingElementLocator(IWebDriver, Settings.TimeWait);

        public IWebElement FindElement(By by)
        {
            bool ElementOnPage = WebWaiter.UntilElementAppearOnPage(by);
            return ElementOnPage ? IWebDriver.FindElement(by) : null;
        }

        public IList<IWebElement> FindElements(By by) => IWebDriver.FindElements(by);

        public void SwitchTo(IBaseElement baseElement) => IWebDriver.SwitchTo().Frame(baseElement.IWebElement);

        public void SwitchToDefaultContent() => IWebDriver.SwitchTo().DefaultContent();

        public Screenshot Screenshot => ((ITakesScreenshot)IWebDriver).GetScreenshot();

        public void Close() => IWebDriver?.Close();

        public void Quit() => IWebDriver?.Quit();

    }
}
