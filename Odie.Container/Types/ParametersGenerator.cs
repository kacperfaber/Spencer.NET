using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ParametersGenerator : IParametersGenerator
    {
        public IParameterGenerator ParameterGenerator;

        public ParametersGenerator(IParameterGenerator parameterGenerator)
        {
            ParameterGenerator = parameterGenerator;
        }

        public IEnumerable<IParameter> GenerateParameters(ParameterInfo[] parameters)
        {
            foreach (ParameterInfo parameterInfo in parameters)
            {
                yield return ParameterGenerator.GenerateParameter(parameterInfo);
            }
        }
    }
}