using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorParametersGenerator
    {
        IEnumerable<object> GenerateParameters(ConstructorInfo constructor, ServiceFlags flags, IContainer container);
        
        IEnumerable<object> GenerateParameters(ConstructorInfo constructor, IContainer container);
    }
}