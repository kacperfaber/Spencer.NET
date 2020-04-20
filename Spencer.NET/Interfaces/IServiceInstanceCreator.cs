namespace Spencer.NET
{
    public interface IServiceInstanceCreator
    {
        object CreateInstance(IService service, IContainer container);
    }
}