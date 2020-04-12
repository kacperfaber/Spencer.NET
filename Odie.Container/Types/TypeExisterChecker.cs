using System;

namespace Odie
{
    public class TypeExisterChecker : ITypeExisterChecker
    {
        public IServiceFinder Finder;

        public TypeExisterChecker(IServiceFinder finder)
        {
            Finder = finder;
        }

        public bool Check(IServiceList list, Type type)
        {
            return Finder.Find(list, type) != null;
        }
    }
}