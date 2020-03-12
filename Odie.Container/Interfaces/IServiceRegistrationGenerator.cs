namespace Odie
{
    public interface IServiceRegistrationGenerator
    {
        IServiceRegistration Generate(ServiceFlags flags);
    }
}