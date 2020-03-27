using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServicesGenerator : IServicesGenerator
    {
        public ITypeIsClassValidator TypeIsClassValidator;
        public IImplementationsFinder ImplementationsFinder;
        public IServiceGenerator ServiceGenerator;

        public ServicesGenerator(ITypeIsClassValidator typeIsClassValidator, IImplementationsFinder implementationsFinder, IServiceGenerator serviceGenerator)
        {
            TypeIsClassValidator = typeIsClassValidator;
            ImplementationsFinder = implementationsFinder;
            ServiceGenerator = serviceGenerator;
        }

        public IEnumerable<IService> GenerateServices(Type type, IAssemblyList assemblies, IContainer container, IConstructorParameters constructorParameters = null, object instance = null)
        {
            if (TypeIsClassValidator.Validate(type))
            {
                IService service = ServiceGenerator.GenerateService(type, container, instance, constructorParameters);
                yield return service;
            }

            else
            {
                IEnumerable<Type> types = ImplementationsFinder.FindImplementations(assemblies, type);

                foreach (Type @class in types)
                {
                    IService service = ServiceGenerator.GenerateService(@class, container, null, constructorParameters);
                    yield return service;
                }
            }
        }
    }
}