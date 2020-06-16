using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceIsAutoValueChecker : IServiceIsAutoValueChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsAutoValue);
        }
    }
}