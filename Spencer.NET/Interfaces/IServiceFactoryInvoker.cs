namespace Spencer.NET
{
    public interface IServiceFactoryInvoker
    {
        IServiceFactoryResult Invoke(IServiceFactory factory);
    }
}