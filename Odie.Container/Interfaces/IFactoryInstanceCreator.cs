namespace Odie
{
    public interface IFactoryInstanceCreator
    {
        object CreateInstance(IFactory factory, IService service, IContainer container);
    }
}