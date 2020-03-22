using System.Reflection;

namespace Odie
{
    public class Constructor : IConstructor
    {
        public ConstructorInfo Instance { get; set; }
        
        public IConstructorParameters Parameters { get; set; }
    }
}