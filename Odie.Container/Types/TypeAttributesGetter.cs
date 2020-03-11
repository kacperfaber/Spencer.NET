using System;
using System.Collections.Generic;

namespace Odie
{
    public class TypeAttributesGetter : ITypeAttributesGetter
    {
        public IEnumerable<TOut> GetAttributes<TOut>(Type targetType)
        {
            foreach (Attribute attr in Attribute.GetCustomAttributes(targetType, typeof(TOut)))
            {
                yield return (TOut) Convert.ChangeType(attr, typeof(TOut));
            }
        }
    }
}