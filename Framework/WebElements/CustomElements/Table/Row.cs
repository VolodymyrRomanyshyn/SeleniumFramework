using Framework.Driver;
using Framework.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using Framework.WebElements.Interfaces;
using Framework.WebElements.Interfaces.ITable;

namespace Framework.WebElements.CustomElements.Table
{
    public class Row : SubPage, IRow
    {
        [FindsBy(How = How.XPath, Using = "td")] private IList<BaseElement> Cells;

        public Row(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public IBaseElement this[int Cell]
        {
            get
            {
                return Cells[Cell];
            }
        }
    }
}
