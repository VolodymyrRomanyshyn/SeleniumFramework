namespace Framework.WebElements.Interfaces.ITable
{
    public interface IRow : IBaseElement
    {
        IBaseElement this[int Cell] { get; }
    }
}
