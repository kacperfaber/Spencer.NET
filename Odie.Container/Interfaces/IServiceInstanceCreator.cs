namespace Odie
{
    public interface IServiceInstanceCreator
    {
        object CreateInstance(IService service, IContainer container);
    }
}