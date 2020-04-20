using System;

namespace Spencer.NET
{
    public class InterfaceGenerator : IInterfaceGenerator
    {
        public ITypeContainsGenericParametersChecker TypeContainsGenericParametersChecker;
        public ITypeGenericParametersProvider GenericParametersProvider;

        public InterfaceGenerator(ITypeGenericParametersProvider genericParametersProvider, ITypeContainsGenericParametersChecker typeContainsGenericParametersChecker)
        {
            GenericParametersProvider = genericParametersProvider;
            TypeContainsGenericParametersChecker = typeContainsGenericParametersChecker;
        }

        public IInterface GenerateInterface(Type type)
        {
            Interface @interface = new InterfaceBuilder()
                .AddType(type)
                .AddGenericParameters(GenericParametersProvider.ProvideGenericTypes(type))
                .HasGenericArguments(TypeContainsGenericParametersChecker.Check(type))
                .Build();

            return @interface;
        }
    }
}