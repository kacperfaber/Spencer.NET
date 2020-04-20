using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceGenericRegistrationBuilder : Builder<ServiceGenericRegistration, ServiceGenericRegistrationBuilder>
    {
        public ServiceGenericRegistrationBuilder(ServiceGenericRegistration o = default) : base(o)
        {
        }

        public ServiceGenericRegistrationBuilder HasGenericParameters(bool contains)
        {
            return Update(x => x.HasGenericParameters = contains);
        }

        public ServiceGenericRegistrationBuilder SetGenericParameters(IEnumerable<Type> parameters)
        {
            return Update(x => x.GenericParameters = new List<Type>(parameters));
        }
    }
}