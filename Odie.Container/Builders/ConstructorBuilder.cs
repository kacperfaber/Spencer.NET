using System.Reflection;

namespace Odie
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

        public ConstructorBuilder AddParameters(ParameterInfo[] parameters)
        {
            return Update(x => x.Parameters = parameters);
        }
    }
}