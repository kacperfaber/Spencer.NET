using System.Linq;

namespace Spencer.NET
{
    public class ServiceDataGenerator : IServiceDataGenerator
    {
        public IServiceData GenerateData(IServiceRegistration registration)
        {
            object instance = registration.RegistrationFlags.SingleOrDefault(x => x.Code == RegistrationFlagConstants.HasInstance)?.Value;
            
            return new ServiceData()
            {
                Instance = instance
            };
        }
    }
}