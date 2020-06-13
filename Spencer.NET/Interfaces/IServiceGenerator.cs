using System;

namespace Spencer.NET
{
    public interface IServiceGenerator
    {
        IService GenerateService(Type @class, IReadOnlyContainer container, object instance = null, IConstructorParameters constructorParameters = null);

        IService GenerateService(Type @class, object instance = null, IConstructorParameters constructorParameters = null);

        IService GenerateService(IServiceRegistration registration);
    }
}