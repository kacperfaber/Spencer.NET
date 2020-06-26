using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassRegistrationConverter : IContainerRegistrationConverter<ClassRegistration>
    {
        public IServiceGenerator ServiceGenerator;

        public ClassRegistrationConverter(IServiceGenerator serviceGenerator)
        {
            ServiceGenerator = serviceGenerator;
        }

        public ClassRegistrationConverter()
        {
            ServiceGenerator = ServiceGeneratorFactory.MakeInstance();
        }

        public IEnumerable<IService> Convert(ClassRegistration registration)
        {
            if (registration.Class.ContainsGenericParameters)
            {
                List<ServiceRegistrationFlag> flags = new List<ServiceRegistrationFlag>(registration.RegistrationFlags)
                {
                    new ServiceRegistrationFlag(RegistrationFlagConstants.GenericParameters, registration.Class.GetGenericArguments()),
                    new ServiceRegistrationFlag(RegistrationFlagConstants.HasGenericParameters, null)
                };

                IService service = ServiceGenerator.GenerateService(registration.Class, flags);
                yield return service;
            }

            else
            {
                IService service = ServiceGenerator.GenerateService(registration.Class, registration.RegistrationFlags);
                yield return service;
            }
        }
    }
}