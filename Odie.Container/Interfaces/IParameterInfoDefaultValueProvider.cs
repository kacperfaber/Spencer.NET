using System.Reflection;

namespace Odie
{
    public interface IParameterInfoDefaultValueProvider
    {
        object Provide(IParameter parameter);
    }
}