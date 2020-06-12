using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IInterfacesExtractor
    {
        IEnumerable<IInterface> ExtractInterfaces(IServiceRegistration registration);
    }
}