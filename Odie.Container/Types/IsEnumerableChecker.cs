using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class IsEnumerableChecker : IIsEnumerableChecker
    {
        public IGenericTypeGenerator GenericGenerator;
        public ITypeGenericParametersProvider GenericParametersProvider;
        public ITypeContainsGenericParametersChecker ContainsGenericParametersChecker;

        public IsEnumerableChecker(IGenericTypeGenerator genericGenerator, ITypeGenericParametersProvider genericParametersProvider, ITypeContainsGenericParametersChecker containsGenericParametersChecker)
        {
            GenericGenerator = genericGenerator;
            GenericParametersProvider = genericParametersProvider;
            ContainsGenericParametersChecker = containsGenericParametersChecker;
        }

        public bool Check(Type type)
        {
            if (ContainsGenericParametersChecker.Check(type))
            {
                Type enumerable = GenericGenerator.Generate(typeof(IEnumerable<>), GenericParametersProvider.ProvideGenericTypes(type).FirstOrDefault());

                return enumerable.IsAssignableFrom(type);
            }

            return false;
        }
    }
}