namespace Odie
{
    public class ServiceInstanceChecker : IServiceInstanceChecker
    {
        public bool Check(IService service)
        {
            return service?.Registration?.Instance != null;
        }
    }
}