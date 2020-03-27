using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorProvider : IConstructorProvider
    {
        public IConstructorChecker ConstructorChecker;
        public IDefaultConstructorProvider DefaultConstructorProvider;
        public IConstructorGenerator ConstructorGenerator;

        public ConstructorProvider(IConstructorChecker constructorChecker, IDefaultConstructorProvider defaultConstructorProvider, IConstructorGenerator constructorGenerator)
        {
            ConstructorChecker = constructorChecker;
            DefaultConstructorProvider = defaultConstructorProvider;
            ConstructorGenerator = constructorGenerator;
        }

        public IConstructor ProvideConstructor(IService service)
        {
            if (service.Flags.HasFlag(ServiceFlagConstants.ServiceCtor))
            {
                ServiceFlag flag = service.Flags.GetFlag(ServiceFlagConstants.ServiceCtor);
                IMember memberParent = flag.Member;

                if (ConstructorChecker.Check(memberParent))
                {
                    return ConstructorGenerator.GenerateConstructor((ConstructorInfo) memberParent.Instance);
                }
            }

            ConstructorInfo constructorInfo = DefaultConstructorProvider.ProvideDefaultConstructor(service.Registration.TargetType);
            return ConstructorGenerator.GenerateConstructor(constructorInfo);
        }

        public IConstructor ProvideConstructor(Type type)
        {
            return ConstructorGenerator.GenerateConstructor(type.GetConstructors().First());
        }
    }
}