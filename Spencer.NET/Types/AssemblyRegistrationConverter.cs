using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class AssemblyRegistrationConverter : IContainerRegistrationConverter<AssemblyRegistration>
    {
        public IServiceGenerator ServiceGenerator;

        public AssemblyRegistrationConverter(IServiceGenerator serviceGenerator)
        {
            ServiceGenerator = serviceGenerator;
        }

        public AssemblyRegistrationConverter()
        {
            ServiceGenerator = ServiceGeneratorFactory.MakeInstance();
        }

        public IEnumerable<IService> Convert(AssemblyRegistration registration)
        {
            foreach (ServiceRegistrationFlag flag in registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.IncludeClass))
            {
                ClassRegistration classRegistration = (ClassRegistration) flag.Value;

                IService service = ServiceGenerator.GenerateService(classRegistration.Class, classRegistration.RegistrationFlags);

                yield return service;
            }
        }
    }
}