using System;

namespace Odie
{
    public class ParameterBuilder : Builder<Parameter, ParameterBuilder>, IDisposable
    {
        public ParameterBuilder(Parameter model = null) : base(model)
        {
        }

        public ParameterBuilder AddValue(object value)
        {
            return Update(x => x.Value = value);
        }

        public ParameterBuilder AddType(Type type)
        {
            return Update(x => x.ParameterType = type);
        }

        public void Dispose()
        {
        }
    }
}