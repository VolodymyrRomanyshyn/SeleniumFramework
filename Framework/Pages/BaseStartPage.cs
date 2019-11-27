using Framework.Driver;
using Framework.Pages.Interfaces;
using SeleniumExtras.PageObjects;

namespace Framework.Pages
{
    public class BaseStartPage : AbstractPage, IBaseStartPage
    {
        public string Url { get; }

        public BaseStartPage(BaseDriver baseDriver, string url) : base(baseDriver)
        {
            Url = url;
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.TimeWait), PageObjectMemberDecorator);
        }

        public BaseStartPage(BaseDriver Driver) : base(Driver)
        {
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.TimeWait), PageObjectMemberDecorator);
        }

        public void OpenUrl()
        {
            BaseDriver.NavigateTo(Url);
            Logger.Info($"Driver open page: {Url}");
        }
    }
}
