using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class FactoryResultResultTypeProvider : IFactoryResultResultTypeProvider
    {
        public IAttributesFinder Finder;

        public FactoryResultResultTypeProvider(IAttributesFinder finder)
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