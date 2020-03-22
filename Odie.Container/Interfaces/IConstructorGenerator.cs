using System.Reflection;

namespace Odie
{
    public interface IConstructorGenerator
    {
        IConstructor GenerateConstructor(ConstructorInfo constructor);
    }
}