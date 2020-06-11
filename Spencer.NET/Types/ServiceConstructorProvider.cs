using System.Collections.Generic;
using System.Reflection;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceConstructorProvider : IServiceConstructorProvider
    {
        public IConstructorInfoListGenerator InfoListGenerator;
        public IConstructorListGenerator ListGenerator;
        public IServiceHasConstructorParametersChecker HasConstructorParametersChecker;
        public IConstructorFinder ConstructorFinder;
        public IConstructorParametersGenerator ParametersGenerator;
        public IConstructorProvider ConstructorProvider;

        public ServiceConstructorProvider(IConstructorInfoListGenerator infoListGenerator, IConstructorListGenerator listGenerator, IServiceHasConstructorParametersChecker hasConstructorParametersChecker, IConstructorFinder constructorFinder, IConstructorParametersGenerator parametersGenerator, IConstructorProvider constructorProvider)
        {
            InfoListGenerator = infoListGenerator;
            ListGenerator = listGenerator;
            HasConstructorParametersChecker = hasConstructorParametersChecker;
            ConstructorFinder = constructorFinder;
            ParametersGenerator = parametersGenerator;
            ConstructorProvider = constructorProvider;
        }

        public IConstructor ProvideConstructor(IService service)
        {
            if (HasConstructorParametersChecker.Check(service))
            {
                ConstructorInfo[] constructorInfos = InfoListGenerator.GenerateList(service.Registration.TargetType);
                IEnumerable<IConstructor> constructors = ListGenerator.GenerateList(constructorInfos);
                IConstructor constructor = ConstructorFinder.FindBy(constructors, service.Registration.RegistrationFlags.SelectValue<IConstructorParameters>(RegistrationFlagConstants.ConstructorParameters));

                return constructor;
            }

            else
            {
                return ConstructorProvider.ProvideConstructor(service);
            }
        }
    }
}