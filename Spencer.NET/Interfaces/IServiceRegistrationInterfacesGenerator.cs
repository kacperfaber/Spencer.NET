using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistrationInterfacesGenerator
    {
        IEnumerable<IInterface> GenerateInterfaces(ServiceFlags flags, Type type);
    }
}