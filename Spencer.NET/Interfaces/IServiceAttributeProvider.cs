using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceAttributeProvider
    {
        IEnumerable<ServiceFlag> ProvideFlags(ServiceFlags flags, string name);
    }
}