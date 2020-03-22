using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class GenericArgumentsComparer : IGenericArgumentComparer
    {
        public bool Compare(IEnumerable<Type> t1, IEnumerable<Type> t2)
        {
            return t1.SequenceEqual(t2);
        }
    }
}