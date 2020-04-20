using System;

namespace Spencer.NET
{
    public interface IServiceGenericRegistrationGenerator
    {
        IServiceGenericRegistration Generate(Type type);
    }
}