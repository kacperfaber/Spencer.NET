using System.Reflection;

namespace Odie
{
    public class ConstructorGenerator : IConstructorGenerator
    {
        public IConstructor GenerateConstructor(ConstructorInfo constructor)
        {
            return new ConstructorBuilder()
                .AddInstance(constructor)
                .AddParameters(constructor.GetParameters())
                .Build();
        }
    }
}