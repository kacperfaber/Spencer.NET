namespace Spencer.NET
{
    public class ServiceInstanceChecker : IServiceInstanceChecker
    {
        public bool Check(IService service)
        {
            return service?.Data?.Instance != null;
        }
    }
}