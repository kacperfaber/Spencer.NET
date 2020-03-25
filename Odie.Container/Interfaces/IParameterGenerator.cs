using System.Reflection;

namespace Odie
{
    public interface IParameterGenerator
    {
        IParameter GenerateParameter(ParameterInfo parameterInfo);
    }
}