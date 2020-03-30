using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IReadOnlyContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IReadOnlyContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters);

        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IService service, IReadOnlyContainer container);
    }
}