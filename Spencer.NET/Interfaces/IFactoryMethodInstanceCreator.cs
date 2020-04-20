namespace Spencer.NET
{
    public interface IFactoryMethodInstanceCreator
    {
        object CreateInstance(IFactory factory, IReadOnlyContainer container);
    }
}