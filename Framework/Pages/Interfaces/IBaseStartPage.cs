namespace Framework.Pages
{
    public interface IBaseStartPage : IAbstractPage
    {
        string Url { get; }
        void OpenUrl();
    }
}
