using System.Reflection;

namespace Odie
{
    public class FactoryGenerator : IFactoryGenerator
    {
        public IFactoryTypeGenerator TypeGenerator;
        public IFactoryResultTypeGenerator ResultTypeGenerator;

        public FactoryGenerator(IFactoryTypeGenerator typeGenerator)
        {
            TypeGenerator = typeGenerator;
        }

        public IFactory GenerateFactory(MemberInfo member)
        {
            using FactoryBuilder builder = new FactoryBuilder();

            return builder
                .AddType(TypeGenerator.Generate(member))
                .AddMember(member)
                .Build();
        }
    }
}