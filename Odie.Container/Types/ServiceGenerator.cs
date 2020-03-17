using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;
        public ITypeIsClassValidator TypeIsClassValidator;
        public IImplementationsFinder ImplementationsFinder;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator, IServiceInfoGenerator infoGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
        }

        public IEnumerable<Service> GenerateServices(Type type, AssemblyList assemblies, object instance = null)
        {
            using (ServiceBuilder builder = new ServiceBuilder())
            {
                if (TypeIsClassValidator.Validate(type)) // TODO change name TypeValidator, little bit weakly 
                {
                    ServiceFlags flags = FlagsGenerator.GenerateFlags(type);
                    IServiceRegistration registration = RegistrationGenerator.Generate(flags, type, instance);
                    IServiceInfo info = InfoGenerator.Generate(type);
                
                    yield return builder
                        .AddFlags(flags)
                        .AddRegistration(registration)
                        .AddInfo(info)
                        .Build();

                    builder.Clear();
                }

                else
                {
                    IEnumerable<Type> types = ImplementationsFinder.FindImplementations(assemblies, type);

                    foreach (Type @class in types)
                    {
                        ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
                        IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance);
                        IServiceInfo info = InfoGenerator.Generate(@class);
                
                        yield return builder
                            .AddFlags(flags)
                            .AddRegistration(registration)
                            .AddInfo(info)
                            .Build();

                        builder.Clear();
                    }
                }
            }
        }
    }
}