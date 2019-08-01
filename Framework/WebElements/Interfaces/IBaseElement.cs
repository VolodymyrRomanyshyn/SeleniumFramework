using Framework.Driver;
using Framework.Driver.Support;
using OpenQA.Selenium;

namespace Framework.WebElements
{
    public interface IBaseElement : IElement
    {
        IWebElement IWebElement { get; }
        string Name { get; }
        BaseDriver BaseDriver { get; }
        string Text { get; }
        string VisibleString();
        bool IsVisible();
        bool IsNotVisible();
        bool IsOnPage { get; }
        string TagValue(string tag);
        TElement CastTo<TElement>() where TElement : Element;
        void MoveToElement();
        void WaitUntilElementDissapear();
        void WaitUntilTagValueIs(string Tag, string Value);
        JavaScriptExecutor JavaScriptExecutor { get; }
    }
}
