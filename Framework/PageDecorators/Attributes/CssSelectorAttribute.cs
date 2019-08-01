using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class CssSelectorAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public CssSelectorAttribute(string locator) => Locator = locator;
        public override By Finder => By.CssSelector(Locator);
    }
}
