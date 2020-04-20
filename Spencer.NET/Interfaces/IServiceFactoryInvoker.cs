namespace Spencer.NET
{
    public interface IServiceFactoryInvoker
    {
        IService Invoke(IServiceFactory factory);
    }
}