namespace Odie
{
    public class ServiceRegistrationInstanceSetter : IServiceRegistrationInstanceSetter
    {
        public void SetInstance(IServiceData data, object instance)
        {
            data.Instance = instance;
        }
    }
}