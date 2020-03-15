using System.Reflection;

namespace Odie
{
    public class ParameterInfoDefaultValueProvider : IParameterInfoDefaultValueProvider
    {
        public object Provide(ParameterInfo parameter)
        {
            return parameter.DefaultValue;
        }
    }
}