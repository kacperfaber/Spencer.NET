using System.Reflection;

namespace Spencer.NET
{
    public class AssemblyRegistration : TypeRegistration, IContainerRegistration
    {
        public Assembly Assembly { get; set; }
    }
}