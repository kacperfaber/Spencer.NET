using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorInvoker
    {
        object InvokeConstructor(ConstructorInfo constructor, IEnumerable<object> parameters);
    }
}