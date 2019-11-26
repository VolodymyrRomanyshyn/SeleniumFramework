namespace Framework.WebElements.Interfaces.ITable
{
    public interface ITable : IBaseElement
    {
        IRow this[int Cell] { get; }
    }
}
