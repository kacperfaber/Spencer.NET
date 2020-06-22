using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ClassesRegistrationBuilder : Builder<ClassesRegistration, ClassRegistrationBuilder, ClassesRegistration>
    {
        public IMemberGenerator MemberGenerator;
        public IConstructorParametersByObjectsGenerator ConstructorParametersGenerator;
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;

        public ClassesRegistrationBuilder(ClassesRegistration model, IServiceRegistrationInterfacesGenerator interfacesGenerator,
            IConstructorParametersByObjectsGenerator constructorParametersGenerator, IMemberGenerator memberGenerator) : base(model)
        {
            InterfacesGenerator = interfacesGenerator;
            ConstructorParametersGenerator = constructorParametersGenerator;
            MemberGenerator = memberGenerator;
        }

        public ClassesRegistrationBuilder Do(Action<ClassRegistration> action)
        {
            foreach (ClassRegistration classRegistration in Object.ClassRegistrations)
            {
                action(classRegistration);
            }

            return this;
        }

        public ClassesRegistrationBuilder AsBaseClass()
        {
            return Do(x => { x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsClass, x.Class.BaseType)); });
        }

        public ClassesRegistrationBuilder AsImplementedInterfaces()
        {
            return Do(x =>
            {
                IEnumerable<IInterface> interfaces = InterfacesGenerator.GenerateInterfaces(new ServiceFlags(), x.Class);

                foreach (IInterface @interface in interfaces)
                {
                    x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.AsInterface, @interface));
                }
            });
        }

        public ClassesRegistrationBuilder IsSingleInstance()
        {
            return Do(x => { x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)); });
        }

        public ClassesRegistrationBuilder IsMultiInstance()
        {
            return Do(x => { x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsMultiInstance, null)); });
        }

        public ClassesRegistrationBuilder AsAutoInstance()
        {
            return Do(x => { x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.IsAutoValue, null)); });
        }

        public ClassesRegistrationBuilder WithConstructorParameters(params object[] args)
        {
            return Do(x =>
            {
                IConstructorParameters parameters = ConstructorParametersGenerator.GenerateParameters(args);

                x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.ConstructorParameters, parameters));
                x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.HasConstructorParameters, true));
            });
        }

        public ClassesRegistrationBuilder WithFactory(string methodName)
        {
            return Do(x =>
            {
                MethodInfo method = x.Class.GetMethods().FirstOrDefault(x => x.Name == methodName);
                IMember member = MemberGenerator.GenerateMember(method);

                x.RegistrationFlags.Add(new ServiceRegistrationFlag(RegistrationFlagConstants.Factory, null) {Member = member});
            });
        }
    }
}