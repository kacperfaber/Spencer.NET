using System;

namespace Spencer.NET
{
    public interface IServiceRegistrationBaseTypeProvider
    {
        Type ProvideBaseType(ServiceFlags flags, Type type);
    }
}