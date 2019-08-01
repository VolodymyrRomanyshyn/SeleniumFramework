using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class PartialLinkTextAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public PartialLinkTextAttribute(string locator) => Locator = locator;
        public override By Finder => By.PartialLinkText(Locator);
    }
}
