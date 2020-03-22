using System.Reflection;

namespace Odie
{
    public interface IConstructor
    {
        ConstructorInfo Instance { get; set; }
        
        ParameterInfo[] Parameters { get; set; }
    }
}