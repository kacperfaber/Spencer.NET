using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceFinder : IServiceFinder
    {
        public ITypeContainsGenericParametersChecker GenericParametersChecker;
        public IGenericServiceFinder GenericServiceFinder;
        public ITypeIsClassValidator TypeIsClassValidator;
        public IServiceByClassFinder ByClassFinder;
        public IServiceByInterfaceFinder ByInterfaceFinder;

        public ServiceFinder(ITypeContainsGenericParametersChecker genericParametersChecker, IGenericServiceFinder genericServiceFinder,
            IServiceByInterfaceFinder byInterfaceFinder, IServiceByClassFinder byClassFinder, ITypeIsClassValidator typeIsClassValidator)
        {
            GenericParametersChecker = genericParametersChecker;
            GenericServiceFinder = genericServiceFinder;
            ByInterfaceFinder = byInterfaceFinder;
            ByClassFinder = byClassFinder;
            TypeIsClassValidator = typeIsClassValidator;
        }

        public IService Find(IServiceList list, Type typeKey)
        {
            if (GenericParametersChecker.Check(typeKey))
            {
                return GenericServiceFinder
                    .FindGenericServices(list, typeKey)
                    .FirstOrDefault();
            }

            bool isClass = TypeIsClassValidator.Validate(typeKey);
            return isClass ? ByClassFinder.FindByClass(list, typeKey) : ByInterfaceFinder.FindByInterface(list, typeKey);
        }

        public IEnumerable<IService> FindMany(IServiceList list, Type type)
        {
            if (GenericParametersChecker.Check(type))
            {
                return GenericServiceFinder.FindGenericServices(list, type);
            }

            return TypeIsClassValidator.Validate(type) ? ByClassFinder.FindManyByClass(list, type) : ByInterfaceFinder.FindManyByInterface(list, type);
        }
    }
}