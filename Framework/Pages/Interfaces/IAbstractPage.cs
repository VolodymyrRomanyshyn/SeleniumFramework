using Framework.Driver;
using Framework.WebElements.Interfaces;

namespace Framework.Pages.Interfaces
{
    public interface IAbstractPage
    {
        string Name { get; }
        BaseDriver BaseDriver { get; }
        TPage Page<TPage>() where TPage : IAbstractPage;
        TElement ElementWithText<TElement>(string text) where TElement : IElement;
        TElement ElementWithTextContains<TElement>(string text) where TElement : IElement;
        void ClickButtonByText(string text);
        IAbstractPage NavigateTo<TPage>(string url) where TPage : IAbstractPage;
        
    }
}
