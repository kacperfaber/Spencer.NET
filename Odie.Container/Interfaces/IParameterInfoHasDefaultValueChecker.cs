using System.Reflection;

namespace Odie
{
    public interface IParameterInfoHasDefaultValueChecker
    {
        bool Check(ParameterInfo parameter);
    }
}