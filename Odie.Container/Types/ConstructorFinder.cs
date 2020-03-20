using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorFinder : IConstructorFinder
    {
        public ConstructorInfo FindBy(ConstructorInfo[] ctors, IRegisterParameters registerParameters)
        {
            IEnumerable<ConstructorInfo> matching = ctors
                .Where(x => x.GetParameters()
                    .All(y => y.HasDefaultValue || registerParameters.Parameters.SingleOrDefault(z =>
                    {
                        return z.Type == y.ParameterType;
                    }) != null)).ToList();
            ConstructorInfo ctor = matching
                .First();

            return ctor;
        }
    }
}