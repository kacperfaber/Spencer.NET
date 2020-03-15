using System;

namespace Odie
{
    public interface IServiceGenericRegistrationGenerator
    {
        IServiceGenericRegistration Generate(Type type);
    }
}