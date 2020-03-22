using System.Reflection;

namespace Odie
{
    public interface IConstructor
    {
        ConstructorInfo Instance { get; set; }
        
        IConstructorParameters Parameters { get; set; }
    }
}