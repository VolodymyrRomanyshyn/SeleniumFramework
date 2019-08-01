namespace Framework.WebElements.Interfaces
{
    public interface ICheckBox : IBaseElement
    {
        bool IsChecked();
        void Check();
        void UnCheck();

    }
}
