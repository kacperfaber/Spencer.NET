using System.Reflection;

namespace Spencer.NET
{
    public class FactoryGenerator : IFactoryGenerator
    {
        public IFactoryTypeGenerator TypeGenerator;
        public IFactoryResultTypeGenerator ResultTypeGenerator;
        public IMethodParametersGenerator MethodParametersGenerator;

        public FactoryGenerator(IFactoryTypeGenerator typeGenerator, IFactoryResultTypeGenerator resultTypeGenerator, IMethodParametersGenerator methodParametersGenerator)
        {
            TypeGenerator = typeGenerator;
            ResultTypeGenerator = resultTypeGenerator;
            MethodParametersGenerator = methodParametersGenerator;
        }

        public IFactory GenerateFactory(IMember member)
        {
            using FactoryBuilder builder = new FactoryBuilder();

            int type = TypeGenerator.Generate(member);

            return builder
                .AddType(type)
                .AddResultType(ResultTypeGenerator.GenerateResultType(member))
                .AddMember(member)
                .AddParentType((member.Instance as MethodInfo).DeclaringType)
                .If(type == FactoryType.StaticMethod, x => x.AddParameters(MethodParametersGenerator.GenerateParameters(member)))
                .Build();
        }
    }
}