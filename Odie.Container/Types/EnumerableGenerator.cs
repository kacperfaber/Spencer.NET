using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class EnumerableGenerator : IEnumerableGenerator
    {
        public ITypeGenericParametersProvider GenericParametersProvider;
        public IGenericTypeGenerator GenericTypeGenerator;

        public EnumerableGenerator(ITypeGenericParametersProvider genericParametersProvider, IGenericTypeGenerator genericTypeGenerator)
        {
            GenericParametersProvider = genericParametersProvider;
            GenericTypeGenerator = genericTypeGenerator;
        }

        public object GenerateEnumerable(Type enumerableType)
        {
            IEnumerable<Type> genericTypes = GenericParametersProvider.ProvideGenericTypes(enumerableType);
            
            Type enumerableOf = genericTypes
                .First();

            Type list = GenericTypeGenerator.Generate(typeof(List<>), enumerableOf);

            return Activator.CreateInstance(list);
        }
    }
}