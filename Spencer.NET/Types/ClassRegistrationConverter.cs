using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassRegistrationConverter : IContainerRegistrationConverter<ClassRegistration>
    {
        public IServiceGenerator ServiceGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;

        public ClassRegistrationConverter(IServiceRegistrationGenerator registrationGenerator, IServiceGenerator serviceGenerator)
        {
            RegistrationGenerator = registrationGenerator;
            ServiceGenerator = serviceGenerator;
        }

        public IEnumerable<IService> Convert(ClassRegistration registration)
        {
            IService service = ServiceGenerator.GenerateService(RegistrationGenerator.Generate(registration.Class, registration.RegistrationFlags));
            yield return service;
        }
    }
}