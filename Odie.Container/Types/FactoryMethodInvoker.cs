using System.Reflection;

namespace Odie
{
    public class FactoryMethodInvoker : IFactoryMethodInvoker
    {
        public IParametersValuesExtractor ValuesExtractor;

        public FactoryMethodInvoker(IParametersValuesExtractor valuesExtractor)
        {
            ValuesExtractor = valuesExtractor;
        }

        public object InvokeMethod(IFactory factory)
        {
            object[] values = ValuesExtractor.ExtractValues(factory.MethodParameters);

            return (factory.Member.Instance as MethodInfo).Invoke(null, values);
        }
    }
}