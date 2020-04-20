namespace Spencer.NET
{
    public interface IServiceResolverProcessor
    {
        void ProcessService(IService service, IContainer container);
    }
}