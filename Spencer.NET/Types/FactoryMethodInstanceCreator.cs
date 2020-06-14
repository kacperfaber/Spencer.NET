namespace Spencer.NET
{
    public class FactoryMethodInstanceCreator : IFactoryMethodInstanceCreator
    {
        public IParametersGenerator ValuesGenerator;
        public IFactoryMethodInvoker MethodInvoker;
        public IMethodParametersGenerator MethodParametersGenerator;

        public FactoryMethodInstanceCreator(IParametersGenerator valuesGenerator, IFactoryMethodInvoker methodInvoker, IMethodParametersGenerator methodParametersGenerator)
        {
            ValuesGenerator = valuesGenerator;
            MethodInvoker = methodInvoker;
            MethodParametersGenerator = methodParametersGenerator;
        }

        public object CreateInstance(IFactory factory, IReadOnlyContainer container)
        {
            factory.MethodParameters = MethodParametersGenerator.GenerateParameters(factory.Member);
            return MethodInvoker.InvokeMethod(factory);
        }
    }
}