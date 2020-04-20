using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class Constructor : IConstructor
    {
        public ConstructorInfo Instance { get; set; }
        
        public IEnumerable<IParameter> Parameters { get; set; }
    }
}