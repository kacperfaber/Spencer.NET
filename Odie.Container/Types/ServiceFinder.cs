using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFinder : IServiceFinder
    {
        public ITypeContainsGenericParametersChecker GenericParametersChecker;
        public IGenericServiceFinder GenericServiceFinder;

        public ServiceFinder(ITypeContainsGenericParametersChecker genericParametersChecker, IGenericServiceFinder genericServiceFinder)
        {
            GenericParametersChecker = genericParametersChecker;
            GenericServiceFinder = genericServiceFinder;
        }

        public Service Find(ServicesList list, Type typeKey)
        {
            return GenericParametersChecker.Check(typeKey)
                ? GenericServiceFinder.FindGenericService(list, typeKey)
                : list.GetServices().FirstOrDefault(x => typeKey.IsAssignableFrom(x.Registration.TargetType));
        }
    }
}