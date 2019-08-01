using Framework.Pages;

namespace Framework.WebElements
{
    public interface IButton : IBaseElement
    {
        void Click();
        TPage ClickAndNavigateTo<TPage>() where TPage : IBasePage;
        void MoveToElementAndClick();
    }
}
