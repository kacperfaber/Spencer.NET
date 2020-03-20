using System.Collections.Generic;

namespace Odie
{
    public interface IContainerStorage
    {
        IServiceList Services { get; set; }
        
        IAssemblyList Assemblies { get; set; }
    }
}