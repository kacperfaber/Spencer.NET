using System.Reflection;

namespace Odie
{
    public interface IParameterHasDefaultValueChecker
    {
        bool Check(IParameter parameter);
    }
}