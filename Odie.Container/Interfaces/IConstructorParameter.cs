namespace Odie
{
    public interface IConstructorParameter : ITypedMember
    {
        object Value { get; set; }
    }
}