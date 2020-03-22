using System.Reflection;

namespace Odie
{
    public class Constructor : IConstructor
    {
        public ConstructorInfo Instance { get; set; }
        
        public ParameterInfo[] Parameters { get; set; }
    }
}