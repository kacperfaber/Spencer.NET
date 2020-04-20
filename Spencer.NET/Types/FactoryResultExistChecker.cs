using System.Linq;

namespace Spencer.NET
{
    public class FactoryResultExistChecker : IFactoryResultExistChecker
    {
        public IAttributesFinder Finder;

        public FactoryResultExistChecker(IAttributesFinder finder)
        {
            Finder = finder;
        }

        public bool Check(IMember member)
        {
            bool any = Finder.FindAttributes<FactoryResult>(member).Any();

            return any;
        }
    }
}