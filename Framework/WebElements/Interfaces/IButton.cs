using Framework.Pages.Interfaces;

namespace Framework.WebElements.Interfaces
{
    public interface IButton : IBaseElement
    {
        void Click();
        TPage ClickAndNavigateTo<TPage>() where TPage : IBasePage;
        void MoveToElementAndClick();
    }
}
