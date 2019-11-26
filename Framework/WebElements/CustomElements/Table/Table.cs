using Framework.Driver;
using Framework.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using Framework.WebElements.Interfaces.ITable;

namespace Framework.WebElements.CustomElements.Table
{
    public class Table : SubPage, ITable
    {
        [FindsBy(How = How.XPath, Using = "tbody/tr")] private IList<Row> Rows;

        public Table(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public IRow this[int Row] => Rows[Row];
    }
}
