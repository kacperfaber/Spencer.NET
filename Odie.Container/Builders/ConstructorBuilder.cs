using System.Reflection;

namespace Odie
{
    public class ConstructorBuilder : Builder<Constructor, ConstructorBuilder>
    {
        public ConstructorBuilder AddInstance(ConstructorInfo ctor)
        {
            return Update(x => x.Instance = ctor);
        }

        public ConstructorBuilder AddParameters(IConstructorParameters parameters)
        {
            return Update(x => x.Parameters = parameters);
        }
    }
}