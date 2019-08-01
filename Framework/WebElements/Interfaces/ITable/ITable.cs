namespace Framework.WebElements
{
    public interface ITable : IBaseElement
    {
        IRow this[int Cell] { get; }
    }
}
