﻿using System.Reflection;

namespace Odie
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

        public IFactory GenerateFactory(MemberInfo member)
        {
            using FactoryBuilder builder = new FactoryBuilder();

            int type = TypeGenerator.Generate(member);

            return builder
                .AddType(type)
                .AddResultType(ResultTypeGenerator.GenerateResultType(member))
                .AddMember(member)
                .If(type == FactoryType.StaticMethod, x => x.AddParameters(MethodParametersGenerator.GenerateParameters(member)))
                .Build();
        }
    }
}