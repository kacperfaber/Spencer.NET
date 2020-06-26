using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class AlwaysNewChecker : IAlwaysNewChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsMultiInstance);
        }
    }
}