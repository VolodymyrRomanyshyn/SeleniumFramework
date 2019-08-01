namespace Framework.WebElements
{
    public interface IRow : IBaseElement
    {
        IBaseElement this[int Cell] { get; }
    }
}
