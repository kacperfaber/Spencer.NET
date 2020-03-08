using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder
    {
        public static ConstructorFinder Current = new ConstructorFinder();
        
        public ConstructorInfo GetConstructor(Type type)
        {
            return type
                .GetConstructors()
                .OrderBy(x => x.GetParameters())
                .First();
        }
    }
}