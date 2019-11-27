namespace Framework.Pages.Interfaces
{
    public interface ILogin : IBasePage
    {
        IBasePage CorrectLogin(string Login, string Pass);
        IBasePage UnCorrectLogin(string Login, string Pass);
    }
}
