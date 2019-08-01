using Framework.Driver;
using OpenQA.Selenium;
using System;

namespace Framework.WebElements
{
    public class TextInputField : BaseElement, ITextInputField
    {
        public TextInputField(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public ITextInputField Clear()
        {
            WebWaiter.UntilToBeVisible(IWebElement);
            IWebElement.Clear();
            Logger.Info($"TextInputField {Name} cleared string");
            return this;
        }

        public ITextInputField SendString(string str)
        {
            WebWaiter.UntilToBeVisible(IWebElement);
            IWebElement.SendKeys(str);
            Logger.Info($"Text input field: {Name} send string: {str}");
            return this;
        }
    }
}
