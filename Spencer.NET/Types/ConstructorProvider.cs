using System;
using System.Linq;
using System.Reflection;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ConstructorProvider : IConstructorProvider
    {
        public IConstructorChecker ConstructorChecker;
        public IDefaultConstructorInfoProvider DefaultConstructorInfoProvider;
        public IConstructorGenerator ConstructorGenerator;

        public ConstructorProvider(IConstructorChecker constructorChecker, IDefaultConstructorInfoProvider defaultConstructorInfoProvider, IConstructorGenerator constructorGenerator)
        {
            ConstructorChecker = constructorChecker;
            DefaultConstructorInfoProvider = defaultConstructorInfoProvider;
            ConstructorGenerator = constructorGenerator;
        }

        public IConstructor ProvideConstructor(IService service)
        {
            if (service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.Constructor))
            {
                ServiceRegistrationFlag flag = service.Registration.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.Constructor);
                IMember memberParent = flag.Member;

                if (ConstructorChecker.Check(memberParent))
                {
                    return ConstructorGenerator.GenerateConstructor((ConstructorInfo) memberParent.Instance);
                }
            }

            else if (service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.DefaultConstructor))
            {
                ServiceRegistrationFlag flag = service.Registration.RegistrationFlags.SingleOrDefault(x => x.Code == RegistrationFlagConstants.DefaultConstructor);
                IMember memberParent = flag.Member;

                if (ConstructorChecker.Check(memberParent))
                {
                    return ConstructorGenerator.GenerateConstructor((ConstructorInfo) memberParent.Instance);
                }
            }

            return ProvideConstructor(service.Registration.TargetType);
        }

        public IConstructor ProvideConstructor(Type type)
        {
            return ConstructorGenerator.GenerateConstructor(type.GetConstructors().First());
        }
    }
}