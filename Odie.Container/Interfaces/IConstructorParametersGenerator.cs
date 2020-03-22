using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorParametersGenerator
    {
        IEnumerable<object> GenerateParameters(IConstructor constructor, ServiceFlags flags, IContainer container);
        
        IEnumerable<object> GenerateParameters(IConstructor constructor, IContainer container);
        
        IEnumerable<object> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters);
    }
}