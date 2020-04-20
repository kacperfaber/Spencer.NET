using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoriesByModifiersFilter : IFactoriesByModifiersFilter
    {
        public IEnumerable<IFactory> Filter(IEnumerable<IFactory> factories)
        {
            foreach (IFactory factory in factories)
            {
                if (factory.Member is MethodInfo method)
                {
                    if (!method.IsGenericMethod && method.IsStatic)
                        yield return factory;
                }
                
                if (factory.Member is FieldInfo field)
                {
                    if (field.IsStatic)
                        yield return factory;
                }
                
                if (factory.Member is PropertyInfo property)
                {
                    if (property.GetGetMethod() != null && property.GetAccessors().Any(x => x.IsStatic))
                        yield return factory;
                }
            }
            
            // TODO test, now it does not putted to system.
        }
    }
}