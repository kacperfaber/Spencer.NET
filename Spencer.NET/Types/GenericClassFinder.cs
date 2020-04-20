using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class GenericClassFinder : IGenericClassFinder
    {
        public ITypeGenericParametersProvider GenericParametersProvider;

        public GenericClassFinder(ITypeGenericParametersProvider genericParametersProvider)
        {
            GenericParametersProvider = genericParametersProvider;
        }

        public IService FindClass(IServiceList list, Type @class)
        {
            IEnumerable<Type> keyParameters = GenericParametersProvider.ProvideGenericTypes(@class);

            return list
                .GetServices()
                .Where(x => x.Registration.GenericRegistration.HasGenericParameters)
                .Where(x => x.Registration.GenericRegistration.GenericParameters.Count() == keyParameters.Count())
                .Where(x => x.Registration.GenericRegistration.GenericParameters.SequenceEqual(keyParameters))
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindClasses(IServiceList list, Type @class)
        {
            IEnumerable<Type> keyParameters = GenericParametersProvider.ProvideGenericTypes(@class);

            return list
                .GetServices()
                .Where(x => x.Registration.GenericRegistration.HasGenericParameters)
                .Where(x => x.Registration.GenericRegistration.GenericParameters.Count() == keyParameters.Count())
                .Where(x => x.Registration.GenericRegistration.GenericParameters.SequenceEqual(keyParameters));
        }
    }
}