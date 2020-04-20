using System.Reflection;

namespace Spencer.NET
{
    public interface IConstructorGenerator
    {
        IConstructor GenerateConstructor(ConstructorInfo constructor);
    }
}