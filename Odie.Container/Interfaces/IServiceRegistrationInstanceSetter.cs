namespace Odie
{
    public interface IServiceRegistrationInstanceSetter
    {
        void SetInstance(IServiceRegistration registration, object instance);
    }
}