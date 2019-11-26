using Framework.Driver;
using Framework.Pages.Interfaces;
using SeleniumExtras.PageObjects;

namespace Framework.Pages
{
    public class BasePage : AbstractPage, IBasePage
    {
        public BasePage(BaseDriver driver) : base(driver)
        {
            PageFactory.InitElements(this, ElementLocator(BaseDriver.Settings.TimeWait), PageObjectMemberDecorator);
        }
    }
}
