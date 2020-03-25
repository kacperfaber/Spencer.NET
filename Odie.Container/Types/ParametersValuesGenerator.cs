using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ParametersValuesGenerator : IParametersValuesGenerator
    {
        public ITypedMemberValueProvider TypedMemberValueProvider;

        public ParametersValuesGenerator(ITypedMemberValueProvider typedMemberValueProvider)
        {
            TypedMemberValueProvider = typedMemberValueProvider;
        }

        public IEnumerable<IParameter> Generate(IEnumerable<IParameter> parameters, IContainer container)
        {
            foreach (IParameter parameter in parameters)
            {
                object value = TypedMemberValueProvider.ProvideValue(parameter, container);
                parameter.Value = value;

                yield return parameter;
            }
        }
    }
}