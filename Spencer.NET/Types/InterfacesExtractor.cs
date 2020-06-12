using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class InterfacesExtractor : IInterfacesExtractor
    {
        public IEnumerable<IInterface> ExtractInterfaces(IServiceRegistration registration)
        {
            IEnumerable<ServiceRegistrationFlag> interfaceFlags = registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);

            foreach (ServiceRegistrationFlag flag in interfaceFlags)
            {
                yield return (IInterface) flag.Value;
            }
        }
    }
}