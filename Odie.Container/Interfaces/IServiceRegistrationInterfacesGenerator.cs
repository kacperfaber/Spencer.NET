using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrationInterfacesGenerator
    {
        IEnumerable<Type> GenerateInterfaces(ServiceFlags flags, Type type);
    }
}