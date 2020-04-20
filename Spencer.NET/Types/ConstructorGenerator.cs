using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorGenerator : IConstructorGenerator
    {
        public IParametersGenerator ParametersGenerator;

        public ConstructorGenerator(IParametersGenerator parametersGenerator)
        {
            ParametersGenerator = parametersGenerator;
        }

        public IConstructor GenerateConstructor(ConstructorInfo constructor)
        {
            return new ConstructorBuilder()
                .AddInstance(constructor)
                .AddParameters(ParametersGenerator.GenerateParameters(constructor.GetParameters()))
                .Build();
        }
    }
}