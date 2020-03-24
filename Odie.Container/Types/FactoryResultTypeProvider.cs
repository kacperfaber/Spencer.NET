using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class FactoryResultTypeProvider : IFactoryResultTypeProvider
    {
        public IAttributesFinder Finder;

        public FactoryResultTypeProvider(IAttributesFinder finder)
        {
            Finder = finder;
        }

        public Type ProvideResultType(MemberInfo member)
        {
            return Finder.FindAttributes<FactoryResult>(member)
                .First()
                .ResultType;
        }
    }
}