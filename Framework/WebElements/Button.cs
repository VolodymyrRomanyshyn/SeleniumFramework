using Framework.Driver;
using OpenQA.Selenium;
using System;
using Framework.Pages.Interfaces;
using Framework.WebElements.Interfaces;

namespace Framework.WebElements
{
    public class Button : BaseElement, IButton
    {
        public Button(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public void Click()
        {
            if (IsOnPage)
            {
                WebWaiter.UntilToBeClickable(IWebElement);
                IWebElement.Click();
                Logger.Info($"Button: {Name} made click");
            }
            else throw new NoSuchElementException($"Unable to find element {Name}");
        }

        public TPage ClickAndNavigateTo<TPage>() where TPage : IBasePage
        {
            if (IsOnPage)
            {
                WebWaiter.UntilToBeClickable(IWebElement);
                IWebElement.Click();
                Logger.Info($"Button: {Name} made click and navigate driver to page: {typeof(TPage).Name}");
                return (TPage)typeof(TPage).GetConstructor(new[] { typeof(BaseDriver) }).Invoke(new object[] { BaseDriver });
            }
            else throw new NoSuchElementException($"Unable to find element {Name}");
        }

        public void MoveToElementAndClick()
        {
            if (IsOnPage)
            {
                BaseDriver.Actions.MoveToElement(IWebElement).Click().Perform();
                Logger.Info($"Mouse hovered over and clicked: {Name}");
            }
            else throw new NullReferenceException($"Element {Name} is not attached on page");
        }

        public bool IsClickable() => WebWaiter.UntilToBeClickable(IWebElement);
    }
}
