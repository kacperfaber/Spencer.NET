using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public ConstructorInfo FindBy(ConstructorInfo[] ctors, IConstructorParameters constructorParameters)
        {
            // TODO make it beauty
            
            List<ConstructorInfo> matchingLen = ctors
                .Where(x => x.GetParameters().Length >= constructorParameters.Parameters.Count)
                .ToList();

            List<ConstructorInfo> matchingParameters = matchingLen.Where(x => x.GetParameters()
                    .All(z => constructorParameters.Parameters.FirstOrDefault(y => y.Type.IsAssignableFrom(z.ParameterType)) != null))
                .ToList();

            List<ConstructorInfo> ordered = matchingParameters.OrderBy(x => x.GetParameters().Length).ToList();
            return ordered.First();
        }
    }
}