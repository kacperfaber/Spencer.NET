using System;
using System.Reflection;

namespace Odie
{
    public class FactoryBuilder : Builder<Factory, FactoryBuilder>, IDisposable
    {
        public FactoryBuilder(Factory model = null) : base(model)
        {
        }

        public FactoryBuilder AddType(int type)
        {
            return Update(x => x.Type = type);
        }

        public FactoryBuilder AddMember(MemberInfo memberInfo)
        {
            return Update(x => x.Member = memberInfo);
        }

        public FactoryBuilder AddResultType(Type type)
        {
            return Update(x => x.ResultType = type);
        }

        public void Dispose()
        {
        }
    }
}