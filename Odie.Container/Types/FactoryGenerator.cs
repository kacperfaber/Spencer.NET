using System.Reflection;

namespace Odie
{
    public class FactoryGenerator : IFactoryGenerator
    {
        public IFactoryTypeGenerator TypeGenerator;
        public IFactoryResultTypeGenerator ResultTypeGenerator;

        public FactoryGenerator(IFactoryTypeGenerator typeGenerator, IFactoryResultTypeGenerator resultTypeGenerator)
        {
            TypeGenerator = typeGenerator;
            ResultTypeGenerator = resultTypeGenerator;
        }

        public IFactory GenerateFactory(MemberInfo member)
        {
            using FactoryBuilder builder = new FactoryBuilder();

            return builder
                .AddType(TypeGenerator.Generate(member))
                .AddResultType(ResultTypeGenerator.GenerateResultType(member))
                .AddMember(member)
                .Build();
        }
    }
}