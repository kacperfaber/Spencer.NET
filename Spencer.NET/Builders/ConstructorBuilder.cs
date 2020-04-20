using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorBuilder : Builder<Constructor, ConstructorBuilder>
    {
        public ConstructorBuilder(Constructor o = default) : base(o)
        {
        }

        public ConstructorBuilder AddInstance(ConstructorInfo ctor)
        {
            return Update(x => x.Instance = ctor);
        }

        public ConstructorBuilder AddParameters(IEnumerable<IParameter> parameters)
        {
            return Update(x => x.Parameters = parameters);
        }
    }
}