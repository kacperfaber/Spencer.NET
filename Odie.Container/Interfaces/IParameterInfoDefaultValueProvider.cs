using System.Reflection;

namespace Odie
{
    public interface IParameterInfoDefaultValueProvider
    {
        object Provide(ParameterInfo parameter);
    }
}