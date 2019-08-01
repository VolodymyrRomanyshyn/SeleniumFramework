using Framework.Driver;
using Framework.WebElements;

namespace Framework.Pages
{
    public interface IAbstractPage
    {
        string Name { get; }
        BaseDriver BaseDriver { get; }
        TPage Page<TPage>() where TPage : IAbstractPage;
        TElement ElementWithText<TElement>(string text) where TElement : IElement;
        TElement ElementWithTextContaints<TElement>(string text) where TElement : IElement;
        void ClickButtonByText(string text);
        IAbstractPage NavigateTo<TPage>(string url) where TPage : IAbstractPage;
        
    }
}
