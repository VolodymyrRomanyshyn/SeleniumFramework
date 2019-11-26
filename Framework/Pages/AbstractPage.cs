using Framework.Driver;
using Framework.PageDecorators;
using Framework.WebElements;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using Framework.Pages.Interfaces;
using Framework.WebElements.Interfaces;

namespace Framework.Pages
{
    public class AbstractPage : IAbstractPage
    {
        public string Name => Name;
        public BaseDriver BaseDriver { get; }
        public Logger Logger { get; }

        protected IPageObjectMemberDecorator PageObjectMemberDecorator;

        public AbstractPage(BaseDriver baseDriver)
        {
            BaseDriver = baseDriver;
            Logger = BaseDriver.Logger;
            PageObjectMemberDecorator = new CustomPageObjectMemberDecorator(BaseDriver);
        }

        public TPage Page<TPage>() where TPage : IAbstractPage
        {
            Logger.Info("Driver on page: " + typeof(TPage).Name);
            return (TPage)typeof(TPage).GetConstructor(new[] { typeof(BaseDriver) }).Invoke(new object[] { BaseDriver });
        }

        public TElement ElementWithText<TElement>(string text) where TElement : IElement
        {
            By by = By.XPath($"//*[text() = '{text}']");
            return ElementBy<TElement>(by);
        }

        public TElement ElementWithTextContaints<TElement>(string text) where TElement : IElement
        {
            By by = By.XPath($"//*[contains(text(),'{text}')]");
            return ElementBy<TElement>(by);
        }

        public void ClickButtonByText(string text) => ElementWithText<Button>(text).Click();

        public IAbstractPage NavigateTo<TPage>(string url) where TPage : IAbstractPage
        {
            BaseDriver.NavigateTo(url);
            return (TPage)typeof(TPage)
                .GetConstructor(new[] { typeof(BaseDriver) })
                .Invoke(new object[] { BaseDriver });
        }

        private TElement ElementBy<TElement>(By by) where TElement : IElement
        {
            var WebElement = BaseDriver.FindElement(by);
            if (WebElement == null)
            {
                Logger.Info("Unable to locate : " + typeof(IElement).ToString() + " element using: " + by.ToString());
                return default(TElement);
            }
            else
            {
                return (TElement)typeof(TElement)
                   .GetConstructor(new[] { typeof(IWebElement), typeof(BaseDriver), typeof(string) })
                   .Invoke(new object[] { WebElement, BaseDriver, by.ToString() });
            }
        }

        protected IElementLocator ElementLocator(TimeSpan timeSpan) => new RetryingElementLocator(BaseDriver.IWebDriver, timeSpan);
    }
}
