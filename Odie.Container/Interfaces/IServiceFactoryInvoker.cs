namespace Odie
{
    public interface IServiceFactoryInvoker
    {
        IService Invoke(IServiceFactory factory);
    }
}