using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructor
    {
        ConstructorInfo Instance { get; set; }
        
        IEnumerable<IParameter> Parameters { get; set; }
    }
}