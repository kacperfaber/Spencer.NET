using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistrationGenerator
    {
        IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null);
        IServiceRegistration Generate(Type type, IEnumerable<ServiceRegistrationFlag> flags);
    }
}