using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceRegistrationInterfacesGenerator : IServiceRegistrationInterfacesGenerator
    {
        public IRegistrationInterfacesFilter Filter;
        public IInterfaceGenerator InterfaceGenerator;

        public ServiceRegistrationInterfacesGenerator(IRegistrationInterfacesFilter filter, ITypeContainsGenericParametersChecker typeContainsGenericParametersChecker, ITypeGenericParametersProvider genericParametersProvider, IInterfaceGenerator interfaceGenerator)
        {
            Filter = filter;
            InterfaceGenerator = interfaceGenerator;
        }

        public IEnumerable<IInterface> GenerateInterfaces(ServiceFlags flags, Type type)
        {
            IEnumerable<Type> interfaces = Filter.Filter(type.GetInterfaces());

            foreach (Type i in interfaces)
            {
                if (!flags.HasFlag(ServiceFlagConstants.ExcludeType, i))
                {
                    yield return InterfaceGenerator.GenerateInterface(type);
                }
            }
        }
    }
}