using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class TypedFactoryExistChecker : ITypedFactoryExistChecker
    {
        public bool CheckExist(IEnumerable<Attribute> attributes)
        {
            return attributes
                .Where(x => x is FactoryAttribute)
                .Where(x => (x as FactoryAttribute).ResultType != null)
                .Any();
        }
    }
}