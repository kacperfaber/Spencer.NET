using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrationInterfacesGenerator
    {
        IEnumerable<IInterface> GenerateInterfaces(ServiceFlags flags, Type type);
    }
}