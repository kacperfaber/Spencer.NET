using System;

namespace Spencer.NET
{
    public class ServiceGenericRegistrationGenerator : IServiceGenericRegistrationGenerator
    {
        public ITypeContainsGenericParametersChecker TypeContainsGenericParametersChecker;
        public ITypeGenericParametersProvider ParametersProvider;

        public ServiceGenericRegistrationGenerator(ITypeGenericParametersProvider parametersProvider,
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