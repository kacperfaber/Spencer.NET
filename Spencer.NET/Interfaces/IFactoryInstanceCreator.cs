namespace Spencer.NET
{
    public interface IFactoryInstanceCreator
    {
        object CreateInstance(IFactory factory, IService service, IReadOnlyContainer readOnlyContainer);
    }
}