using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class TagNameAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public TagNameAttribute(string locator) => Locator = locator;
        public override By Finder => By.TagName(Locator);
    }
}
