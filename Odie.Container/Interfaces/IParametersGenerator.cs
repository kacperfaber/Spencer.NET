using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(ParameterInfo[] parameters);
    }
}