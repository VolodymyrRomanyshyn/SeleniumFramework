namespace Framework.WebElements
{
    public interface ITextInputField : IBaseElement
    {
        ITextInputField Clear();
        ITextInputField SendString(string str);
    }
}
