namespace Framework.Pages.Interfaces
{
    public interface IBaseStartPage : IAbstractPage
    {
        string Url { get; }
        void OpenUrl();
    }
}
