using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class XPathAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public XPathAttribute(string locator) => Locator = locator;
        public override By Finder => By.XPath(Locator);
    }
}
