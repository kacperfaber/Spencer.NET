using System;
using System.Reflection;

namespace Spencer.NET
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

            if (factory.Type == FactoryType.PublicMethod)
            {
                object instance = Activator.CreateInstance(factory.ParentType); // TODO Activator :<
                
                return (factory.Member.Instance as MethodInfo).Invoke(instance, values);
            }
            
            return (factory.Member.Instance as MethodInfo).Invoke(null, values);
        }
    }
}