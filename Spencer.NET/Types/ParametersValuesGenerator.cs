using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ParametersValuesGenerator : IParametersValuesGenerator
    {
        public ITypedMemberValueProvider TypedMemberValueProvider;

        public ParametersValuesGenerator(ITypedMemberValueProvider typedMemberValueProvider)
        {
            TypedMemberValueProvider = typedMemberValueProvider;
        }

        public IEnumerable<IParameter> Generate(IEnumerable<IParameter> parameters, IReadOnlyContainer container)
        {
            foreach (IParameter parameter in parameters)
            {
                object value = TypedMemberValueProvider.ProvideValue(parameter.Type, container);
                parameter.Value = value;

                yield return parameter;
            }
        }
    }
}