using System;

namespace Spencer.NET
{
    public interface IServiceRegistrationGenerator
    {
        IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null);
    }
}