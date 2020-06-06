using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistrationFlagGenerator
    {
        IEnumerable<ServiceRegistrationFlag> GenerateFlags(ServiceFlags flags, Type type, object instance, IConstructorParameters constructorParameters);
    }
}