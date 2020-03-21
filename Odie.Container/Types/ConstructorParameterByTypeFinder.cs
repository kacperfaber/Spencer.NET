using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorParameterByTypeFinder : IConstructorParameterByTypeFinder
    {
        public IConstructorParameter FindByType(IConstructorParameters parameters, Type type)
        {
            return parameters.Parameters.First(x => type.IsAssignableFrom(x.Type));
        }
    }
}