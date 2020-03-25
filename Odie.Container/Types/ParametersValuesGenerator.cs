using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ParametersValuesGenerator : IParametersValuesGenerator
    {
        public IValueProvider ValueProvider;

        public ParametersValuesGenerator(IValueProvider valueProvider)
        {
            ValueProvider = valueProvider;
        }

        public void Generate(IEnumerable<IParameter> parameters, IContainer container)
        {
            foreach (IParameter parameter in parameters)
            {
                object value = ValueProvider.ProvideValue(parameter.ParameterType, container);
                parameter.Value = value;
            }
        }
    }
}