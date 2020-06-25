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
        public IConstructorGenerator ConstructorGenerator;
        public IConstructorInfoListGenerator ConstructorInfoListGenerator;
        public IDefaultConstructorInfoProvider DefaultConstructorInfoProvider;

        public ServiceRegistrationFlagGenerator(IBaseTypeFinder baseTypeFinder, IServiceRegistrationInterfacesGenerator interfacesGenerator,
            IConstructorGenerator constructorGenerator, IConstructorInfoListGenerator constructorInfoListGenerator,
            IDefaultConstructorInfoProvider defaultConstructorInfoProvider)
        {
            BaseTypeFinder = baseTypeFinder;
            InterfacesGenerator = interfacesGenerator;
            ConstructorGenerator = constructorGenerator;
            ConstructorInfoListGenerator = constructorInfoListGenerator;
            DefaultConstructorInfoProvider = defaultConstructorInfoProvider;
        }

        public IEnumerable<ServiceRegistrationFlag> GenerateFlags(ServiceFlags flags, Type type, object instance, IConstructorParameters constructorParameters)
        {
            if (instance != null)
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasInstance, instance);

            if (constructorParameters != null)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasConstructorParameters, true);
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.ConstructorParameters, constructorParameters);
            }

            Type baseType = BaseTypeFinder.GetBaseTypeAnotherOf(type, null, typeof(object));

            if (baseType != null)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, baseType);
            }

            IEnumerable<IInterface> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);

            foreach (IInterface @interface in interfaces)
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.AsInterface, @interface);
            }

            ConstructorInfo[] constructors = ConstructorInfoListGenerator.GenerateList(type);

            if (flags.HasFlag(ServiceFlagConstants.ServiceCtor))
            {
                ServiceFlag flag = flags.GetFlag(ServiceFlagConstants.ServiceCtor);
                IMember member = flag.Member;
                IConstructor serviceConstructor = ConstructorGenerator.GenerateConstructor((ConstructorInfo) member.Instance);

                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, serviceConstructor);
            }

            else
            {
                ConstructorInfo defaultConstructorInfo = DefaultConstructorInfoProvider.ProvideDefaultConstructor(constructors);
                IConstructor defaultConstructor = ConstructorGenerator.GenerateConstructor(defaultConstructorInfo);

                if (defaultConstructor != null)
                {
                    yield return new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, defaultConstructor);
                }
            }

            foreach (ConstructorInfo constructor in constructors)
            {
                IConstructor ctor = ConstructorGenerator.GenerateConstructor(constructor);
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.Constructor, ctor);
            }

            Type[] genericArguments = type.GetGenericArguments();

            if (genericArguments.Any())
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.HasGenericParameters, null);
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.GenericParameters, genericArguments);
            }

            foreach (ServiceFlag factoryFlag in flags.GetFlags(ServiceFlagConstants.ServiceFactory))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.Factory, null) {Member = factoryFlag.Member};
            }

            if (flags.HasFlag(ServiceFlagConstants.AutoValue))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsAutoValue, null);
            }
            
            if (!flags.HasFlag(ServiceFlagConstants.SingleInstance) && !flags.HasFlag(ServiceFlagConstants.MultiInstance))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null);
            }

            if (flags.HasFlag(ServiceFlagConstants.SingleInstance) && flags.HasFlag(ServiceFlagConstants.MultiInstance))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null);
            }
            
            else if (flags.HasFlag(ServiceFlagConstants.SingleInstance))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null);
            }

            else if (flags.HasFlag(ServiceFlagConstants.MultiInstance))
            {
                yield return new ServiceRegistrationFlag(RegistrationFlagConstants.IsMultiInstance, null);
            }
        }
    }
}