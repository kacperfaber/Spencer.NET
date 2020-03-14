namespace Odie
{
    public class ServiceInstanceChecker : IServiceInstanceChecker
    {
        public bool Check(Service service)
        {
            return service?.Registration?.Instance != null;
        }
    }
}