using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(ParameterInfo[] parameters);
    }
}