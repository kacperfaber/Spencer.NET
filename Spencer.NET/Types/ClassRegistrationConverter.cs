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
            IService service = ServiceGenerator.GenerateService(registration.Class, registration.RegistrationFlags);
            yield return service;
        }
    }
}