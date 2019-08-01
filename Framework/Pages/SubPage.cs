using Framework.Driver;
using Framework.PageDecorators;
using Framework.WebElements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Pages
{
    public class SubPage : BaseElement, ISubPage
    {
        public SubPage(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
            PageFactory.InitElements(this, 
                new RetryingElementLocator(IWebElement, Driver.Settings.TimeWait), 
                new CustomPageObjectMemberDecorator(BaseDriver));
        }

        public TPage Page<TPage>() where TPage : IBasePage
        {
            Logger.Info("Driver on page: " + typeof(TPage).Name);
            return (TPage)typeof(TPage).GetConstructor(new[] { typeof(BaseDriver) }).Invoke(new object[] { BaseDriver });
        }
    }
}
