using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class FactoryBuilder : Builder<Factory, FactoryBuilder, IFactory>
    {
        public FactoryBuilder(Factory model = null) : base(model)
        {
        }

        public FactoryBuilder AddType(int type)
        {
            return Update(x => x.Type = type);
        }

        public FactoryBuilder AddMember(IMember memberInfo)
        {
            return Update(x => x.Member = memberInfo);
        }

        public FactoryBuilder AddResultType(Type type)
        {
            return Update(x => x.ResultType = type);
        }

        public FactoryBuilder AddParameters(IEnumerable<IParameter> parameters)
        {
            return Update(x => x.MethodParameters = parameters);
        }

        public FactoryBuilder AddParentType(Type type)
        {
            return Update(x => x.ParentType = type);
        }
    }
}