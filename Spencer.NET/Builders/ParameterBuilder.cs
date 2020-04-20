using System;

namespace Spencer.NET
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
            return Update(x => x.Type = type);
        }

        public ParameterBuilder HasDefaultValue(bool hasDefaultValue)
        {
            return Update(x => x.HasDefaultValue = hasDefaultValue);
        }

        public ParameterBuilder AddDefaultValue(object value)
        {
            return Update(x => x.DefaultValue = value);
        }
        
        public void Dispose()
        {
        }
    }
}