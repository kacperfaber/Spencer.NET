namespace Odie
{
    public class ServiceRegistrationInstanceSetter : IServiceRegistrationInstanceSetter
    {
        public void SetInstance(IServiceRegistration registration, object instance)
        {
            registration.Instance = instance;
        }
    }
}