using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IConstructorInvoker
    {
        object InvokeConstructor(ConstructorInfo constructor, IEnumerable<object> parameters);

        object InvokeConstructor(IConstructor constructor, IEnumerable<object> parameters);
    }
}