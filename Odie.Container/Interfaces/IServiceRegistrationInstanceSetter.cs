namespace Odie
{
    public interface IServiceRegistrationInstanceSetter
    {
        void SetInstance(IServiceData data, object instance);
    }
}