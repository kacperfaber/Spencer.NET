using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class AssemblyRegistrationBuilder : Builder<AssemblyRegistration, AssemblyRegistrationBuilder, AssemblyRegistration>
    {
        public AssemblyRegistrationBuilder(AssemblyRegistration model = null) : base(model)
        {
        }

        public AssemblyRegistrationBuilder ExcludeClass<TClass>() where TClass : class
        {
            return Update(x =>
            {
                IEnumerable<ServiceRegistrationFlag> flags = x.RegistrationFlags
                    .Where(x => x.Code == RegistrationFlagConstants.IncludeClass)
                    .Where(x => x.Value is ClassRegistration)
                    .Where(x => (x.Value as ClassRegistration).Class == typeof(TClass));

                foreach (ServiceRegistrationFlag flag in flags)
                {
                    x.RegistrationFlags.Remove(flag);
                }
            });
        }

        public AssemblyRegistrationBuilder IncludeClass<T>() where T : class
        {
            ClassRegistration registration = new ClassRegistration() {Class = typeof(T)};

            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IncludeClass, registration)));
        }

        public AssemblyRegistrationBuilder IncludeClasses(Func<Type, bool> func)
        {
            return Update(x =>
            {
                IEnumerable<Type> classes = x.Assembly.GetTypes().Where(x => x.IsClass);

                foreach (Type @class in classes)
                {
                    if (func(@class))
                    {
                        ClassRegistration registration = new ClassRegistration() {Class = @class};

                        x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IncludeClass, registration));
                    }
                }
            });
        }

        public AssemblyRegistrationBuilder ExcludeClasses(Func<Type, bool> func)
        {
            return Update(x =>
            {
                IEnumerable<ServiceRegistrationFlag> flags = x.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.IncludeClass);

                foreach (ServiceRegistrationFlag flag in flags)
                {
                    ClassRegistration classRegistration = flag.Value as ClassRegistration;

                    if (func(classRegistration.Class))
                    {
                        x.RegistrationFlags.Remove(flag);
                    }
                }
            });
        }

        public ClassRegistrationBuilder SelectClass<TClass>()
        {
            Type type = typeof(TClass);

            ClassRegistration registration = (ClassRegistration) Object.RegistrationFlags
                .Where(x => x.Code == RegistrationFlagConstants.IncludeClass)
                .Where(x => x.Value is ClassRegistration)
                .Where(x => (x.Value as ClassRegistration).Class == type)
                .First()
                .Value;

            InterfaceGenerator interfaceGenerator = new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker());
            return new ClassRegistrationBuilder(registration, new ConstructorParametersByObjectsGenerator(new TypeGetter()),
                new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                    new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), interfaceGenerator),
                new MemberGenerator(new MemberFlagsGenerator()), interfaceGenerator);
        }

        public ClassesRegistrationBuilder SelectClasses(Func<Type, bool> func)
        {
        }

        public ClassesRegistrationBuilder SelectClasses()
        {
        }
    }
}