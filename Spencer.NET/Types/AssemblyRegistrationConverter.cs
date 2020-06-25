using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class AssemblyRegistrationConverter : IContainerRegistrationConverter<AssemblyRegistration>
    {
        public IServiceRegistrationGenerator ServiceRegistrationGenerator;
        public IServiceGenerator ServiceGenerator;

        public AssemblyRegistrationConverter(IServiceRegistrationGenerator serviceRegistrationGenerator, IServiceGenerator serviceGenerator)
        {
            ServiceRegistrationGenerator = serviceRegistrationGenerator;
            ServiceGenerator = serviceGenerator;
        }

        public IEnumerable<IService> Convert(AssemblyRegistration registration)
        {
            foreach (ServiceRegistrationFlag flag in registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.IncludeClass))
            {
                ClassRegistration classRegistration = (ClassRegistration) flag.Value;

                IServiceRegistration classServiceRegistration = ServiceRegistrationGenerator.Generate(classRegistration.Class, classRegistration.RegistrationFlags);
                IService service = ServiceGenerator.GenerateService(classServiceRegistration);

                yield return service;
            }
        }
    }
}