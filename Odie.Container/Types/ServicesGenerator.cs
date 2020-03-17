using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServicesGenerator : IServiceGenerator
    {
        public ITypeIsClassValidator TypeIsClassValidator;
        public IImplementationsFinder ImplementationsFinder;
        public ITypeServiceGenerator TypeServiceGenerator;

        public ServicesGenerator(ITypeIsClassValidator typeIsClassValidator, IImplementationsFinder implementationsFinder, ITypeServiceGenerator typeServiceGenerator)
        {
            TypeIsClassValidator = typeIsClassValidator;
            ImplementationsFinder = implementationsFinder;
            TypeServiceGenerator = typeServiceGenerator;
        }

        public IEnumerable<Service> GenerateServices(Type type, AssemblyList assemblies, object instance = null)
        {
            if (TypeIsClassValidator.Validate(type))
            {
                yield return TypeServiceGenerator.GenerateService(type);
            }

            else
            {
                IEnumerable<Type> types = ImplementationsFinder.FindImplementations(assemblies, type);

                foreach (Type @class in types)
                {
                    Service service = TypeServiceGenerator.GenerateService(@class);
                    yield return service;
                }
            }
        }
    }
}