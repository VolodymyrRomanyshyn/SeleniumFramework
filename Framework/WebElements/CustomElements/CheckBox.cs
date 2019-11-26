using Framework.Driver;
using Framework.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.WebElements.CustomElements
{
    public class CheckBox : SubPage
    {

        [FindsBy(How = How.TagName, Using = "input")] private Button CheckBoxElement;

        public CheckBox(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public bool IsChecked() => CheckBoxElement.TagValue("ng-reflect-model").Equals("true") ? true : false;

        public void Check()
        {
            if (!IsChecked())
            {
                CheckBoxElement.Click();
            }
        }

        public void UnCheck()
        {
            if (IsChecked())
            {
                CheckBoxElement.Click();
            }
        }
    }
}
