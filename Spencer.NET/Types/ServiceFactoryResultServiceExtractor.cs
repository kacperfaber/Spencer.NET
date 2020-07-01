namespace Spencer.NET
{
    public class ServiceFactoryResultServiceExtractor : IServiceFactoryResultServiceExtractor
    {
        public IService ExtractService(IServiceFactoryResult factoryResult)
        {
            return factoryResult.Service;
        }
    }
}