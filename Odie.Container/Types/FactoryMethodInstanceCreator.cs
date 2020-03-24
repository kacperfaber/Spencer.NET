namespace Odie
{
    public class FactoryMethodInstanceCreator : IFactoryMethodInstanceCreator
    {
        public IParametersValuesGenerator ValuesGenerator;
        public IFactoryMethodInvoker MethodInvoker;

        public FactoryMethodInstanceCreator(IParametersValuesGenerator valuesGenerator, IFactoryMethodInvoker methodInvoker)
        {
            ValuesGenerator = valuesGenerator;
            MethodInvoker = methodInvoker;
        }

        public object CreateInstance(IFactory factory, IContainer container)
        {
            ValuesGenerator.Generate(factory.MethodParameters, container);
            return MethodInvoker.InvokeMethod(factory);
        }
    }
}