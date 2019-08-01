using Framework.BrowserSettings;
using Framework.Driver;
using Framework.PageDecorators;
using NLog;
using SeleniumExtras.PageObjects;

namespace Framework.Pages
{
    public class BasePage : AbstractPage, IBasePage
    {
        public BasePage(BaseDriver driver) : base(driver)
        {
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.TimeWait), PageObjectMemberDecorator);
        }

        public BasePage(BaseDriver Driver, string Url) : base(Driver)
        {
            BaseDriver.NavigateTo(Url);
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.TimeWait), PageObjectMemberDecorator);
            Logger.Info($"Driver open page: {Url}");
        }
    }
}
