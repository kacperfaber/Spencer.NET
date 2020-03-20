using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public ConstructorInfo FindBy(ConstructorInfo[] ctors, IRegisterParameters registerParameters)
        {
            // TODO make it beauty
            // TODO he cannot takes 2 same types like int, int
            
            List<ConstructorInfo> matchingLen = ctors
                .Where(x => x.GetParameters().Length >= registerParameters.Parameters.Count)
                .ToList();

            List<ConstructorInfo> matchingParameters = matchingLen.Where(x => x.GetParameters()
                    .All(z => registerParameters.Parameters.FirstOrDefault(y => y.Type.IsAssignableFrom(z.ParameterType)) != null))
                .ToList();

            List<ConstructorInfo> ordered = matchingParameters.OrderBy(x => x.GetParameters().Length).ToList();
            return ordered.First();
        }
    }
}