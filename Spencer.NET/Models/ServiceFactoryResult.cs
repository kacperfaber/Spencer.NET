namespace Spencer.NET
{
    public class ServiceFactoryResult : IServiceFactoryResult
    {
        public IService Service { get; set; }

        public ServiceFactoryResult(IService service)
        {
            Service = service;
        }
    }
}