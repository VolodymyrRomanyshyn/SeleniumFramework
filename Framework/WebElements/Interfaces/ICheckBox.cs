namespace Framework.WebElements.Interfaces
{
    public interface ICheckBox : IBaseElement
    {
        bool IsChecked { get; }
        void Check();
        void UnCheck();
    }
}
