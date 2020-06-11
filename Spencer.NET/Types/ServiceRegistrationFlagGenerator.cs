using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ServiceRegistrationFlagGenerator : IServiceRegistrationFlagGenerator
    {
        public IBaseTypeFinder BaseTypeFinder;
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        public IFactoriesProvider FactoriesProvider;

        public IEnumerable<ServiceRegistrationFlag> GenerateFlags(ServiceFlags flags, Type type, object instance, IConstructorParameters constructorParameters)
        {
            if (instance != null)
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasInstance, instance);

            if (constructorParameters != null)
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasConstructorParameters, constructorParameters);

            Type baseType = BaseTypeFinder.GetBaseTypeAnotherOf(type, null, typeof(object));

            if (baseType != null)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, baseType);
            }

            IEnumerable<IInterface> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);
            if (interfaces.Any())
            {
                foreach (IInterface @interface in interfaces)
                {
                    yield return new ServiceRegistrationFlag(RegistrationFlagConstants.AsInterface, @interface);
                }
            }

            // TODO change to IConstructor
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo defaultConstructor = constructors.Where(x => x.GetParameters().Length == 0).FirstOrDefault();

            if (defaultConstructor != null)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, defaultConstructor);
            }

            foreach (ConstructorInfo constructor in constructors)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.Constructor, constructor);
            }
            
            Type[] genericArguments = type.GetGenericArguments();

            if (genericArguments.Any())
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasGenericParameters, null);
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.GenericParameters, genericArguments);
            }
        }
    }
}