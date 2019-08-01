using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ClassNameAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public ClassNameAttribute(string locator) => Locator = locator;
        public override By Finder => By.ClassName(Locator);
    }
}
