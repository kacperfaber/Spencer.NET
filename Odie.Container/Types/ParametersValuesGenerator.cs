using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ParametersValuesGenerator : IParametersValuesGenerator
    {
        public IParameterValueProvider ParameterValueProvider;

        public ParametersValuesGenerator(IParameterValueProvider parameterValueProvider)
        {
            ParameterValueProvider = parameterValueProvider;
        }

        public void Generate(IEnumerable<IParameter> parameters, IContainer container)
        {
            foreach (IParameter parameter in parameters)
            {
                object value = ParameterValueProvider.ProvideValue(null, container);
                parameter.Value = value;
            }
        }
    }
}