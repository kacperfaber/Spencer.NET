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

        public IEnumerable<IService> GenerateServices(Type type, IAssemblyList assemblies, IContainer container, object instance = null)
        {
            if (TypeIsClassValidator.Validate(type))
            {
                IService service = TypeServiceGenerator.GenerateService(type, container, instance);
                yield return service;
            }

            else
            {
                IEnumerable<Type> types = ImplementationsFinder.FindImplementations(assemblies, type);

                foreach (Type @class in types)
                {
                    IService service = TypeServiceGenerator.GenerateService(@class, container);
                    yield return service;
                }
            }
        }
    }
}