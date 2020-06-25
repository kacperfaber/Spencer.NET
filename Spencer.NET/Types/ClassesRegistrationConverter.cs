using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassesRegistrationConverter : IContainerRegistrationConverter<ClassesRegistration>
    {
        public IServiceGenerator ServiceGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;

        public ClassesRegistrationConverter(IServiceRegistrationGenerator registrationGenerator, IServiceGenerator serviceGenerator)
        {
            ServiceGenerator = serviceGenerator;
            RegistrationGenerator = registrationGenerator;
        }

        public IEnumerable<IService> Convert(ClassesRegistration registration)
        {
            foreach (ClassRegistration classRegistration in registration.ClassRegistrations)
            {
                IService service = ServiceGenerator.GenerateService(RegistrationGenerator.Generate(classRegistration.Class, classRegistration.RegistrationFlags));
                yield return service;
            }
        }
    }
}