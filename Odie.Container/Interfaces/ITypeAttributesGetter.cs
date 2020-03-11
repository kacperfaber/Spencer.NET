using System;
using System.Collections.Generic;

namespace Odie
{
    public interface ITypeAttributesGetter
    {
        IEnumerable<TOut> GetAttributes<TOut>(Type targetType);
    }
}