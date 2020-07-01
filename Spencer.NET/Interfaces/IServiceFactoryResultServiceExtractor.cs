namespace Spencer.NET
{
    public interface IServiceFactoryResultServiceExtractor
    {
        IService ExtractService(IServiceFactoryResult factoryResult);
    }
}