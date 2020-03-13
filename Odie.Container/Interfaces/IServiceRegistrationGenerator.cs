using System;

namespace Odie
{
    public interface IServiceRegistrationGenerator
    {
        IServiceRegistration Generate(ServiceFlags flags, Type type);
    }
}