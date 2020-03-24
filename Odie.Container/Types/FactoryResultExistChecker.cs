using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class FactoryResultExistChecker : IFactoryResultExistChecker
    {
        public IAttributesFinder Finder;

        public FactoryResultExistChecker(IAttributesFinder finder)
        {
            Finder = finder;
        }

        public bool Check(MemberInfo member)
        {
            bool any = Finder.FindAttributes<FactoryResult>(member).Any();

            return any;
        }
    }
}