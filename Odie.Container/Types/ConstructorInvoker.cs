using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorInvoker : IConstructorInvoker
    {
        public object InvokeConstructor(ConstructorInfo constructor, IEnumerable<object> parameters)
        {
            return constructor.Invoke(parameters.ToArray());
        }

        public object InvokeConstructor(IConstructor constructor, IEnumerable<object> parameters)
        {
            return constructor.Instance.Invoke(parameters.ToArray());
        }
    }
}