using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationBuilder : Builder<ServiceRegistration, ServiceRegistrationBuilder>
    {
        public ServiceRegistrationBuilder(ServiceRegistration o = default) : base(o)
        {
        }

        public ServiceRegistrationBuilder AddType(Type type)
        {
            return Update(x => x.TargetType = type);
        }

        public ServiceRegistrationBuilder SetInterfaces(IEnumerable<Type> interfaces)
        {
            return Update(x => x.Interfaces = new List<Type>(interfaces));
        }

        public ServiceRegistrationBuilder AddBaseType(Type baseType)
        {
            return Update(x => x.BaseType = baseType);
        }

        public ServiceRegistrationBuilder AddInstance(object instance)
        {
            return Update(x => x.Instance = instance);
        }

        public ServiceRegistrationBuilder SetHasGenericParameters(bool hasGenericParameters)
        {
            return Update(x => x.HasGenericParameters = hasGenericParameters);
        }

        public ServiceRegistrationBuilder SetGenericParameters(IEnumerable<Type> parameters)
        {
            return Update(x => x.GenericParameters = new List<Type>(parameters));
        }
    }
}