using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoryMethodInvoker : IFactoryMethodInvoker
    {
        public IParametersValuesGenerator ValuesGenerator;
        public IParametersValuesExtractor ValuesExtractor;

        public FactoryMethodInvoker(IParametersValuesExtractor valuesExtractor, IParametersValuesGenerator valuesGenerator)
        {
            ValuesExtractor = valuesExtractor;
            ValuesGenerator = valuesGenerator;
        }

        public object InvokeMethod(IFactory factory, IReadOnlyContainer container)
        {
            IEnumerable<IParameter> parameters = ValuesGenerator.Generate(factory.MethodParameters, container);
            object[] values = ValuesExtractor.ExtractValues(parameters);

            if (factory.Type == FactoryType.PublicMethod)
            {
                object instance = Activator.CreateInstance(factory.ParentType); // TODO Activator :<
                
                return (factory.Member.Instance as MethodInfo).Invoke(instance, values);
            }
            
            return (factory.Member.Instance as MethodInfo).Invoke(null, values);
        }
    }
}