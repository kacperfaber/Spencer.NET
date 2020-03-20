using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public ConstructorInfo FindBy(ConstructorInfo[] ctors, IRegisterParameters registerParameters)
        {
            ConstructorInfo ctor = ctors
                .Where(x => x.GetParameters()
                    .All(y => y.HasDefaultValue || registerParameters.Parameters.SingleOrDefault(z => z.Type == y.ParameterType) != null))
                .First();

            return ctor;
        }
    }
}