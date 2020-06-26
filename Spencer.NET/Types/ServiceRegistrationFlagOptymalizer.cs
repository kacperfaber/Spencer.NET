using System.Collections.Generic;
using System.Linq;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceRegistrationFlagOptymalizer : IServiceRegistrationFlagOptymalizer
    {
        public IEnumerable<ServiceRegistrationFlag> Optymalize(IEnumerable<ServiceRegistrationFlag> flags)
        {
            foreach (ServiceRegistrationFlag flag in flags)
            {
                if (flag.Code == RegistrationFlagConstants.IsSingleInstance || flag.Code == RegistrationFlagConstants.IsMultiInstance)
                {
                    if (flags.Has(RegistrationFlagConstants.IsSingleInstance) || flags.Has(RegistrationFlagConstants.IsMultiInstance))
                    {
                        yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null);
                        continue;
                    }

                    if (flags.Has(RegistrationFlagConstants.IsSingleInstance) || flags.Has(RegistrationFlagConstants.IsMultiInstance))
                    {
                        yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsMultiInstance, null);
                        continue;
                    }
                }

                yield return flag;
            }
        }
    }
}