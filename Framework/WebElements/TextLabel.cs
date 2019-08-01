using Framework.Driver;
using OpenQA.Selenium;
using System;

namespace Framework.WebElements
{
    public class TextLabel : BaseElement
    {
        public TextLabel(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public override string ToString()
        {
            WebWaiter.UntilToBeVisible(IWebElement);
            var Text = IWebElement.Text;
            Logger.Info($"Text lable: {Name} contains folloing test: {Text}");
            return Text;
        }

        public string WaitUtilTextToBePresentInElement(string text)
        {
            WebWaiter.WaitUtilTextToBePresentInElement(IWebElement, text);
            Logger.Info($"Text lable: {Name} contains folloing test: {text}");
            return IWebElement.Text;
        }
    }
}
