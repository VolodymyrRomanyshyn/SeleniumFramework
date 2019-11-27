using Framework.Driver;
using Framework.Pages.Interfaces;
using SeleniumExtras.PageObjects;

namespace Framework.Pages
{
    public class BaseReportPage : AbstractPage, IBasePage
    {
        public BaseReportPage(BaseDriver driver) : base(driver)
        {
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.ReportTimeWait), PageObjectMemberDecorator);
        }
    }
}
