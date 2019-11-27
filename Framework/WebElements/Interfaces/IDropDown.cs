namespace Framework.WebElements.Interfaces
{
    public interface IDropDown : IBaseElement
    {
        void ClickByText(string text);
        void SelectAnyOption();
        bool IsValueSelected(string value);
    }
}
