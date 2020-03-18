using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFinder : IServiceFinder
    {
        public ITypeContainsGenericParametersChecker GenericParametersChecker;
        public IGenericServiceFinder GenericServiceFinder;
        public ITypeIsClassValidator TypeIsClassValidator;
        public IServiceByClassFinder ByClassFinder;
        public IServiceByInterfaceFinder ByInterfaceFinder;

        public ServiceFinder(ITypeContainsGenericParametersChecker genericParametersChecker, IGenericServiceFinder genericServiceFinder, IServiceByInterfaceFinder byInterfaceFinder, IServiceByClassFinder byClassFinder, ITypeIsClassValidator typeIsClassValidator)
        {
            GenericParametersChecker = genericParametersChecker;
            GenericServiceFinder = genericServiceFinder;
            ByInterfaceFinder = byInterfaceFinder;
            ByClassFinder = byClassFinder;
            TypeIsClassValidator = typeIsClassValidator;
        }

        public IService Find(ServicesList list, Type typeKey)
        {
            if (GenericParametersChecker.Check(typeKey)) // TODO classgenericparameterschecker and interface...
            {
                return GenericServiceFinder.FindGenericService(list, typeKey);
            }

            return TypeIsClassValidator.Validate(typeKey) ? ByClassFinder.FindByClass(list, typeKey) : ByInterfaceFinder.FindByInterface(list, typeKey);
        }
    }
}