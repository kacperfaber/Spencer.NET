using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IGenericArgumentComparer
    {
        bool Compare(IEnumerable<Type> t1, IEnumerable<Type> t2);
    }
}