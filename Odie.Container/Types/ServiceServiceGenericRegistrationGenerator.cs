using System;
using System.Linq;

namespace Odie
{
    public class ServiceServiceGenericRegistrationGenerator : IServiceGenericRegistrationGenerator
    {
        public ITypeContainsGenericParametersChecker TypeContainsGenericParametersChecker;
        public ITypeGenericParametersProvider ParametersProvider;

        public ServiceServiceGenericRegistrationGenerator(ITypeGenericParametersProvider parametersProvider,
            ITypeContainsGenericParametersChecker typeContainsGenericParametersChecker)
        {
            ParametersProvider = parametersProvider;
            TypeContainsGenericParametersChecker = typeContainsGenericParametersChecker;
        }

        public IServiceGenericRegistration Generate(Type type)
        {
            ServiceGenericRegistrationBuilder builder = new ServiceGenericRegistrationBuilder();

            return builder
                .HasGenericParameters(TypeContainsGenericParametersChecker.Check(type))
                .SetGenericParameters(ParametersProvider.ProvideGenericTypes(type)).Build();
        }
    }
}