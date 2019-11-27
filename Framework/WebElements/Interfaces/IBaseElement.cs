using Framework.Driver;
using Framework.Driver.Support;
using OpenQA.Selenium;

namespace Framework.WebElements.Interfaces
{
    public interface IBaseElement : IElement
    {
        IWebElement IWebElement { get; }
        string Name { get; }
        BaseDriver BaseDriver { get; }
        string Text { get; }
        string VisibleText { get; }
        bool IsVisible { get; }
        bool IsNotVisible { get; }
        bool IsOnPage { get; }
        string TagValue(string tag);
        TElement CastTo<TElement>() where TElement : Element;
        void MoveToElement();
        void WaitUntilElementDisappear();
        void WaitUntilTagValueIs(string Tag, string Value);
        JavaScriptExecutor JavaScriptExecutor { get; }
    }
}
