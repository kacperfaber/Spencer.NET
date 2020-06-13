using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Spencer.NET
{
    public class ClassRegistrationBuilder : Builder<ClassRegistration, ClassRegistrationBuilder, ClassRegistration>
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        public IConstructorParametersByObjectsGenerator ParametersGenerator;

        public ClassRegistrationBuilder(ClassRegistration model) : base(model)
        {
        }

        public ClassRegistrationBuilder AsClass(Type @class)
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, @class))); // Type or IClass TODO
        }

        public ClassRegistrationBuilder AsClass<TClass>() where TClass : class
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, typeof(TClass)))); // Type or IClass TODO
        }

        public ClassRegistrationBuilder AsBaseClass()
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, Object.Type.BaseType)));
        }

        public ClassRegistrationBuilder AsImplementedInterfaces()
        {
            IEnumerable<IInterface> interfaces = InterfacesGenerator.GenerateInterfaces(new ServiceFlags(), Object.Type);

            return Update(x =>
            {
                foreach (IInterface @interface in interfaces)
                {
                    x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsInterface, @interface));
                }
            });
        }

        public ClassRegistrationBuilder AsSingleInstance()
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)));
        }
        
        public ClassRegistrationBuilder AsMultiInstance()
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsMultiInstance, null)));
        }

        public ClassRegistrationBuilder WithInstance(object instance)
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.HasInstance, instance)));
        }
        
        public ClassRegistrationBuilder WithInstance<T>(T instance)
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.HasInstance, instance)));
        }

        public ClassRegistrationBuilder WithConstructorParameters(params object[] args)
        {
            IConstructorParameters parameters = ParametersGenerator.GenerateParameters(args);
            
            return Update(x =>
            {
                x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.ConstructorParameters, parameters));
                x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.HasConstructorParameters, true));
            });
        }
    }
}