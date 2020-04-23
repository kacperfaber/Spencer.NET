using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceAttributeProvider : IServiceAttributeProvider
    {
        public IEnumerable<ServiceFlag> ProvideFlags(ServiceFlags flags, string name) 
        {
            return flags.Where(x => x.Name == name);
        }
    }
}