namespace Framework.WebElements.Interfaces
{
    public interface ITextInputField : IBaseElement
    {
        ITextInputField Clear();
        ITextInputField SendString(string str);
    }
}
