using System;
using System.Linq;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class ConstructorProvider : IConstructorProvider
    {
        public IConstructorChecker ConstructorChecker;
        public IDefaultConstructorProvider DefaultConstructorProvider;

        public ConstructorProvider(IConstructorChecker constructorChecker, IDefaultConstructorProvider defaultConstructorProvider)
        {
            ConstructorChecker = constructorChecker;
            DefaultConstructorProvider = defaultConstructorProvider;
        }

        public ConstructorInfo ProvideConstructor(Type type, ServiceFlags flags)
        {
            if (flags.HasFlag(ServiceFlagConstants.ServiceCtor))
            {
                ServiceFlag flag = flags.GetFlag(ServiceFlagConstants.ServiceCtor);
                MemberInfo memberParent = flag.Parent;

                if (ConstructorChecker.Check(memberParent))
                {
                    return (ConstructorInfo) memberParent;
                }
            }

            return DefaultConstructorProvider.ProvideDefaultConstructor(type);
        }
    }
}