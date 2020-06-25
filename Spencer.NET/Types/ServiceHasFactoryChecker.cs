using System.Linq;

namespace Spencer.NET
{
    public class ServiceHasFactoryChecker : IServiceHasFactoryChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.RegistrationFlags.Any(x => x.Code == RegistrationFlagConstants.Factory);
        }
    }
}