using System;
using System.Collections.Generic;

namespace Odie
{
    public class GenericServiceFinder : IGenericServiceFinder
    {
        public IGenericInterfaceFinder InterfaceFinder;
        public IGenericClassFinder ClassFinder;
        public ITypeIsClassValidator IsClassValidator;

        public GenericServiceFinder(ITypeIsClassValidator isClassValidator, IGenericClassFinder classFinder, IGenericInterfaceFinder interfaceFinder)
        {
            IsClassValidator = isClassValidator;
            ClassFinder = classFinder;
            InterfaceFinder = interfaceFinder;
        }

        public IEnumerable<IService> FindGenericServices(IServiceList list, Type type)
        {
            if (IsClassValidator.Validate(type))
            {
                return ClassFinder.FindClasses(list, type);
            }

            return InterfaceFinder.FindInterfaces(list, type);
        }
    }
}