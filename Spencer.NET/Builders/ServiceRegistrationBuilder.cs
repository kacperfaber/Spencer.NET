using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationBuilder : Builder<ServiceRegistration, ServiceRegistrationBuilder, IServiceRegistration>
    {
        public ServiceRegistrationBuilder(ServiceRegistration o = default) : base(o)
        {
        }

        public ServiceRegistrationBuilder AddType(Type type)
        {
            return Update(x => x.TargetType = type);
        }

        public ServiceRegistrationBuilder SetInterfaces(IEnumerable<IInterface> interfaces)
        {
            return Update(x => x.Interfaces = new List<IInterface>(interfaces));
        }

        public ServiceRegistrationBuilder AddBaseType(Type baseType)
        {
            return Update(x => x.BaseType = baseType);
        }

        public ServiceRegistrationBuilder AddGenericRegistration(IServiceGenericRegistration genericRegistration)
        {
            return Update(x => x.GenericRegistration = genericRegistration);
        }

        public ServiceRegistrationBuilder AddRegisterParameters(IConstructorParameters parameters)
        {
            return Update(x => x.ConstructorParameter = parameters);
        }
    }
}