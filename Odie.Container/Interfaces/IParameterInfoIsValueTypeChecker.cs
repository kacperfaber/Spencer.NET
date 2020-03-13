using System.Reflection;

namespace Odie
{
    public interface IParameterInfoIsValueTypeChecker
    {
        bool Check(ParameterInfo parameter);
    }
}