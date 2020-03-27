using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters);

        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IService service, IContainer container);
    }
}