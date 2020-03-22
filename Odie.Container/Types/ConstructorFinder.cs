using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public IConstructor FindBy(IEnumerable<IConstructor> ctors, IConstructorParameters constructorParameters)
        {
            List<IConstructor> matchingLen = ctors
                .Where(x => x.Parameters.Length >= constructorParameters.Parameters.Count)
                .ToList();

            List<IConstructor> matchingParameters = matchingLen.Where(
                    x => x.Parameters.All(y => constructorParameters.Parameters.FirstOrDefault(z => z.Type.IsAssignableFrom(y.ParameterType)) != null))
                .ToList();

            List<IConstructor> ordered = matchingParameters.OrderBy(x => x.Parameters.Length).ToList();

            IConstructor result = ordered.FirstOrDefault();

            return result;
        }
    }
}