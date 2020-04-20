namespace Spencer.NET
{
    public interface IConstructorParameter : ITypedMember
    {
        object Value { get; set; }
    }
}