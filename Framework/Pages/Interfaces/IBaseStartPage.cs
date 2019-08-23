namespace Framework.Pages
{
    interface IBaseStartPage : IAbstractPage
    {
        string Url { get; }
        void OpenUrl();
    }
}
