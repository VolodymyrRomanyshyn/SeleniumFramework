using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Framework.PageDecorators.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class IdAttribute : AbstractFindsByAttribute
    {
        private string Locator;
        public IdAttribute(string locator) => Locator = locator;
        public override By Finder => By.Id(Locator);
    }
}
