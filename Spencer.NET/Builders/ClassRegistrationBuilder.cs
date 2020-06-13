using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassRegistrationBuilder : Builder<ClassRegistration, ClassRegistrationBuilder, ClassRegistration>
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        
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
    }
}