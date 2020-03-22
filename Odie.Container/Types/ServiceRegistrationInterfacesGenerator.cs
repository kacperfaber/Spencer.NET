using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationInterfacesGenerator : IServiceRegistrationInterfacesGenerator
    {
        public IRegistrationInterfacesFilter Filter;
        public ITypeContainsGenericParametersChecker TypeContainsGenericParametersChecker;
        public ITypeGenericParametersProvider GenericParametersProvider;

        public ServiceRegistrationInterfacesGenerator(IRegistrationInterfacesFilter filter, ITypeContainsGenericParametersChecker typeContainsGenericParametersChecker, ITypeGenericParametersProvider genericParametersProvider)
        {
            Filter = filter;
            TypeContainsGenericParametersChecker = typeContainsGenericParametersChecker;
            GenericParametersProvider = genericParametersProvider;
        }

        public IEnumerable<IInterface> GenerateInterfaces(ServiceFlags flags, Type type)
        {
            IEnumerable<Type> interfaces = Filter.Filter(type.GetInterfaces());

            foreach (Type i in interfaces)
            {
                using InterfaceBuilder builder = new InterfaceBuilder();
                
                if (!flags.HasFlag(ServiceFlagConstants.ExcludeType, i))
                {
                    yield return builder
                        .AddType(i)
                        .AddGenericParameters(GenericParametersProvider.ProvideGenericTypes(i))
                        .IsGeneric(TypeContainsGenericParametersChecker.Check(i))
                        .Build();
                }
            }
        }
    }
}