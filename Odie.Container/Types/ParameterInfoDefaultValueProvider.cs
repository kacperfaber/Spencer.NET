using System.Reflection;

namespace Odie
{
    public class ParameterInfoDefaultValueProvider : IParameterInfoDefaultValueProvider
    {
        public object Provide(IParameter parameter)
        {
            return parameter.DefaultValue;
        }
    }
}