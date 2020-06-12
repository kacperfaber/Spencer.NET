using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceHasConstructorParametersChecker : IServiceHasConstructorParametersChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.HasConstructorParameters)
                   && service.Registration.RegistrationFlags.SelectValueOrNull<IConstructorParameters>(RegistrationFlagConstants.ConstructorParameters) != null;
        }
    }
}