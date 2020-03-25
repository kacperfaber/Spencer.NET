using System.Reflection;

namespace Odie
{
    public class ParameterDefaultValueProvider : IParameterDefaultValueProvider
    {
        public object Provide(IParameter parameter)
        {
            return parameter.DefaultValue;
        }
    }
}