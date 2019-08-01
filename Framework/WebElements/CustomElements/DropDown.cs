using Framework.Driver;
using Framework.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

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
                new Button(IWebElement, BaseDriver, Name).Click();
                foreach (Button button in Options)
                {
                    if (button.ToString().Equals(text))
                    {
                        button.Click();
                        break;
                    }
                }
            }
        }

        public bool IsValueSelected(string value) => new BaseElement(IWebElement, BaseDriver, Name).TagValue("ng-reflect-model").Equals(value);

        public void SelectAnyOption()
        {
            var AnyOption = Options[new Random(Options.Count).Next()].TagValue("ng - reflect - model");
            ClickByText(AnyOption);
        }
    }
}
