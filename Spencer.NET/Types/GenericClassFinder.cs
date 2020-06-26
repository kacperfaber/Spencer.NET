using System;
using System.Collections.Generic;
using System.Linq;
using Spencer.NET.Extensions;

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
            IEnumerable<IService> assignableServices = list.GetServices().Where(x => @class.IsAssignableFrom(x.Registration.TargetType));
            IEnumerable<Type> genericParameters = GenericParametersProvider.ProvideGenericTypes(@class);

            return assignableServices.Where(x => x.Registration.TargetType.GetGenericArguments().SequenceEqual(genericParameters))
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindClasses(IServiceList list, Type @class)
        {
            IEnumerable<IService> assignableServices = list.GetServices().Where(x => @class.IsAssignableFrom(x.Registration.TargetType));
            IEnumerable<Type> genericParameters = GenericParametersProvider.ProvideGenericTypes(@class);

            return assignableServices.Where(x =>
                x.Registration.TargetType.GetGenericArguments().SequenceEqual(genericParameters));
        }
    }
}