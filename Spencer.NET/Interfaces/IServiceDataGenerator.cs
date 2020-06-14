namespace Spencer.NET
{
    public interface IServiceDataGenerator
    {
        IServiceData GenerateData(IServiceRegistration registration);
    }
}