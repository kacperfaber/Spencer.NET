using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorInvoker : IConstructorInvoker
    {
        public object InvokeConstructor(IConstructor constructor, IEnumerable<object> parameters)
        {
            object[] parametersArr = parameters.ToArray();
            return constructor.Instance.Invoke(parametersArr);
        }
    }
}