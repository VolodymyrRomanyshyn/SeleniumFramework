using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class NameAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public NameAttribute(string locator) => Locator = locator;
        public override By Finder => By.Name(Locator);
    }
}
