using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassesRegistrationConverter : IContainerRegistrationConverter<ClassesRegistration>
    {
        public IServiceGenerator ServiceGenerator;

        public ClassesRegistrationConverter(IServiceGenerator serviceGenerator)
        {
            ServiceGenerator = serviceGenerator;
        }

        public ClassesRegistrationConverter()
        {
            ServiceGenerator = ServiceGeneratorFactory.MakeInstance();
        }

        public IEnumerable<IService> Convert(ClassesRegistration registration)
        {
            foreach (ClassRegistration classRegistration in registration.ClassRegistrations)
            {
                IService service = ServiceGenerator.GenerateService(classRegistration.Class, classRegistration.RegistrationFlags);
                yield return service;
            }
        }
    }
}