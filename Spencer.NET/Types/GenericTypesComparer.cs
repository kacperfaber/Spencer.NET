using System;

namespace Spencer.NET
{
    public class GenericTypesComparer : IGenericTypesComparer
    {
        public IGenericArgumentComparer ArgumentsComparer;
        public ITypeGenericParametersProvider GenericParametersProvider;

        public GenericTypesComparer(ITypeGenericParametersProvider genericParametersProvider, IGenericArgumentComparer argumentsComparer)
        {
            GenericParametersProvider = genericParametersProvider;
            ArgumentsComparer = argumentsComparer;
        }

        public bool Compare(Type t1, Type t2)
        {
            bool b = t1.FullName == t2.FullName;

            if (b)
            {
                return ArgumentsComparer.Compare(GenericParametersProvider.ProvideGenericTypes(t1), GenericParametersProvider.ProvideGenericTypes(t2));
            }

            return false;
        }
    }
}