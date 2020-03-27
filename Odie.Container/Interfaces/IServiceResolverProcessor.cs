namespace Odie
{
    public interface IServiceResolverProcessor
    {
        void ProcessService(IService service, IContainer container);
    }
}