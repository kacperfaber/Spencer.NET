using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoryMethodInvoker : IFactoryMethodInvoker
    {
        public IParametersValuesExtractor ValuesExtractor;
        public IParametersValuesGenerator ValuesGenerator;

        public FactoryMethodInvoker(IParametersValuesExtractor valuesExtractor, IParametersValuesGenerator valuesGenerator)
        {
            ValuesExtractor = valuesExtractor;
            ValuesGenerator = valuesGenerator;
        }

        public object InvokeMethod(IFactory factory, IReadOnlyContainer container)
        {
            IEnumerable<IParameter> parameters = ValuesGenerator.Generate(factory.MethodParameters, container);
            object[] values = ValuesExtractor.ExtractValues(parameters);

            return (factory.Member.Instance as MethodInfo).Invoke(null, values);
        }
    }
}