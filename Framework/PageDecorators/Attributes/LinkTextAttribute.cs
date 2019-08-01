using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class LinkTextAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public LinkTextAttribute(string locator) => Locator = locator;
        public override By Finder => By.LinkText(Locator);
    }
}
