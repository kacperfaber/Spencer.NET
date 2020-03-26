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

        public IConstructor ProvideConstructor(Type type, ServiceFlags flags)
        {
            if (flags.HasFlag(ServiceFlagConstants.ServiceCtor))
            {
                ServiceFlag flag = flags.GetFlag(ServiceFlagConstants.ServiceCtor);
                IMember memberParent = flag.Parent;

                if (ConstructorChecker.Check(memberParent.Instance))
                {
                    return ConstructorGenerator.GenerateConstructor((ConstructorInfo) memberParent.Instance);
                }
            }

            ConstructorInfo constructorInfo = DefaultConstructorProvider.ProvideDefaultConstructor(type);
            return ConstructorGenerator.GenerateConstructor(constructorInfo);
        }

        public IConstructor ProvideConstructor(Type type)
        {
            return ConstructorGenerator.GenerateConstructor(type.GetConstructors().First());
        }
    }
}