using Framework.Driver;
using Framework.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Framework.WebElements
{
    public class DropDown : SubPage, IDropDown
    {
        [FindsBy(How = How.TagName, Using = "option")] private IList<Button> Options;

        public DropDown(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public void ClickByText(string text)
        {
            if (!IsValueSelected(text))
            {
                CastTo<Button>().Click();
                Options.FirstOrDefault(el => el.VisibleText.Equals(text)).Click();
            }
        }

        public bool IsValueSelected(string value) => new BaseElement(IWebElement, BaseDriver, Name).TagValue("ng-reflect-model").Equals(value);

        public void SelectAnyOption()
        {
            Options.Random().Click();
        }
    }
}
