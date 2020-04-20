using System.Reflection;

namespace Spencer.NET
{
    public interface IParameterGenerator
    {
        IParameter GenerateParameter(ParameterInfo parameterInfo);
    }
}