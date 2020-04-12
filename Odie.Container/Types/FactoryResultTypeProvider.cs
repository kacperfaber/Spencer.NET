using System;
using System.Linq;

namespace Odie
{
    public class FactoryResultTypeProvider : IFactoryResultTypeProvider
    {
        public IAttributesFinder Finder;

        public FactoryResultTypeProvider(IAttributesFinder finder)
        {
            Finder = finder;
        }

        public Type ProvideResultType(IMember member)
        {
            return Finder.FindAttributes<FactoryResult>(member)
                .First()
                .ResultType;
        }
    }
}