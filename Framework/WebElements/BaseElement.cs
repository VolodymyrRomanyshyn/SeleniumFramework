using Framework.Driver;
using Framework.Driver.Support;
using Framework.Waiter;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.WebElements
{
    public class BaseElement : Element, IBaseElement
    {
        public BaseDriver BaseDriver { get; }
        public IWebElement IWebElement { get; }
        protected WebWaiter WebWaiter { get; }
        public string Name { get; }
        protected Logger Logger { get; }
        public JavaScriptExecutor JavaScriptExecutor { get; }


        public BaseElement(IWebElement Element, BaseDriver Driver, string ElementName)
        {
            IWebElement = Element;
            BaseDriver = Driver;
            WebWaiter = BaseDriver.WebWaiter;
            Name = ElementName;
            Logger = BaseDriver.Logger;
            JavaScriptExecutor = new JavaScriptExecutor(IWebElement);
        }

        public string Text => IWebElement.Text;

        public override string ToString() => IWebElement.Text;

        public virtual string VisibleString()
        {
            var IsVisible = WebWaiter.UntilToBeVisible(IWebElement);
            if (IsVisible)
            {
                return IWebElement.Text;
            }
            else
            {
                throw new NullReferenceException($"Element: {IWebElement}  is not visible on Page");
            }
        }

        public virtual bool IsVisible()
        {
            var visibility = WebWaiter.UntilToBeVisible(IWebElement);
            Logger.Info($"Element: {Name} is visible: {visibility}");
            return visibility;
        }

        public bool IsNotVisible()
        {
            var unVisibility = WebWaiter.UntilToBeUnVisible(IWebElement);
            Logger.Info($"Element: {Name} is not visible: {unVisibility}");
            return unVisibility;
        }

        public bool IsOnPage
        {
            get
            {
                object type;
                try
                {
                    type = IWebElement.GetType();
                    Logger.Info($"Element: {Name} is on page");
                }
                catch (NoSuchElementException)
                {
                    type = null;
                    Logger.Info($"Element: {Name} is unable on page");
                }

                if (type != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string TagValue(string tag) => IWebElement.GetAttribute(tag);

        public TElement CastTo<TElement>() where TElement : Element
        {
            Logger.Info($"casting element to: {typeof(TElement).Name.ToString()}");
            return (TElement)typeof(TElement)
                .GetConstructor(new[] { typeof(IWebElement), typeof(BaseDriver), typeof(string) })
                .Invoke(new object[] { IWebElement, BaseDriver, Name });
        }

        public void MoveToElement()
        {
            if (IsOnPage)
            {
                BaseDriver.Actions.MoveToElement(IWebElement).Perform();
                Logger.Info($"Mouse is focused on element: {Name}");
            }
            else
            {
                throw new NullReferenceException($"Element {Name} is ont attached on page");
            }
        }

        public void WaitUntilElementDissapear()
        {
            Logger.Info("Waiting until element Dissapear");
            WebWaiter.UntilToBeVisible(IWebElement);
            WebWaiter.WaitUntilElementDissapear(IWebElement);
        }

        public void WaitUntilTagValueIs(string Tag, string Value) => WebWaiter.UntilTagHasValue(IWebElement, Tag, Value);
    }
}
