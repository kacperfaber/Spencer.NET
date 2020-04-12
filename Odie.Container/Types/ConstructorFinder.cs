using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public IConstructor FindBy(IEnumerable<IConstructor> ctors, IConstructorParameters constructorParameters)
        {
            // TODO please.
            
            List<IConstructor> matchingLen = ctors
                .Where(x => x.Parameters.Count() >= constructorParameters.Parameters.Count)
                .ToList();

            List<IConstructor> matchingParameters = matchingLen.Where(
                    x => x.Parameters.All(y => constructorParameters.Parameters.FirstOrDefault(z => z.Type.IsAssignableFrom(y.Type)) != null))
                .ToList();

            List<IConstructor> ordered = matchingParameters.OrderBy(x => x.Parameters.Count()).ToList();

            IConstructor result = ordered.FirstOrDefault();

            return result;
        }
    }
}