using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceGenerator
    {
        IService GenerateService(Type @class, IReadOnlyContainer container, object instance = null, IConstructorParameters constructorParameters = null);

        IService GenerateService(Type @class, object instance = null, IConstructorParameters constructorParameters = null);

        IService GenerateService(IServiceRegistration registration);

        IService GenerateService(Type @class, IEnumerable<ServiceRegistrationFlag> flags);
    }
}