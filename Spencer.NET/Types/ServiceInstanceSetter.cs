namespace Spencer.NET
{
    public class ServiceInstanceSetter : IServiceInstanceSetter
    {
        public void SetInstance(IService service, object instance)
        {
            service.Data.Instance = instance;
        }
    }
}