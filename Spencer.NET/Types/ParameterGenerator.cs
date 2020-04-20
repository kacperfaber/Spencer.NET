using System.Reflection;

namespace Spencer.NET
{
    public class ParameterGenerator : IParameterGenerator
    {
        public IParameter GenerateParameter(ParameterInfo parameterInfo)
        {
            return new ParameterBuilder()
                .AddType(parameterInfo.ParameterType)
                .AddDefaultValue(parameterInfo.DefaultValue)
                .HasDefaultValue(parameterInfo.HasDefaultValue)
                .Build();
        }
    }
}