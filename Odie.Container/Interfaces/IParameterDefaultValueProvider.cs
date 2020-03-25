using System.Reflection;

namespace Odie
{
    public interface IParameterDefaultValueProvider
    {
        object Provide(IParameter parameter);
    }
}