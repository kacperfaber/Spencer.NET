using System.Collections.Generic;
using System.Linq;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceRegistrationFlagOptymalizer : IServiceRegistrationFlagOptymalizer
    {
        public IEnumerable<ServiceRegistrationFlag> Optymalize(IEnumerable<ServiceRegistrationFlag> flags)
        {
            ICollection<ServiceRegistrationFlag> collection = (ICollection<ServiceRegistrationFlag>) flags;

            if (!collection.Has(RegistrationFlagConstants.IsMultiInstance) && !collection.Has(RegistrationFlagConstants.IsSingleInstance))
            {
                collection.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null));
            }

            if (collection.Has(RegistrationFlagConstants.IsMultiInstance) && collection.Has(RegistrationFlagConstants.IsSingleInstance))
            {
                collection.Remove(collection.SingleOrDefault(x => x.Code == RegistrationFlagConstants.IsMultiInstance));
            }

            return collection;
        }
    }
}