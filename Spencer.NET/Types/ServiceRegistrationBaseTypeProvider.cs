using System;

namespace Spencer.NET
{
    public class ServiceRegistrationBaseTypeProvider : IServiceRegistrationBaseTypeProvider
    {
        public IBaseTypeFinder BaseTypeFinder;

        public ServiceRegistrationBaseTypeProvider(IBaseTypeFinder baseTypeFinder)
        {
            BaseTypeFinder = baseTypeFinder;
        }

        public Type ProvideBaseType(ServiceFlags flags, Type type)
        {
            if (flags.HasFlag(ServiceFlagConstants.AsBaseType))
                return BaseTypeFinder.GetBaseType(type);

            return null;
        }
    }
}