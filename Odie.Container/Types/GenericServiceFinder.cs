using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class GenericServiceFinder : IGenericServiceFinder
    {
        public ITypeGenericParametersProvider GenericParametersProvider;

        public GenericServiceFinder(ITypeGenericParametersProvider genericParametersProvider)
        {
            GenericParametersProvider = genericParametersProvider;
        }

        public Service FindGenericService(ServicesList list, Type type)
        {
            IEnumerable<Type> keyParameters = GenericParametersProvider.ProvideGenericTypes(type);

            return list.GetServices()
                .Where(x => x.Registration.GenericRegistration.HasGenericParameters)
                .Where(x => x.Registration.GenericRegistration.GenericParameters.Count() == keyParameters.Count())
                .Where(x => x.Registration.GenericRegistration.GenericParameters.SequenceEqual(keyParameters))
                .FirstOrDefault();
        }
    }
}