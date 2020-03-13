using System.Reflection;

namespace Odie
{
    public class ParameterInfoIsValueTypeChecker : IParameterInfoIsValueTypeChecker
    {
        public bool Check(ParameterInfo parameter)
        {
            return parameter.ParameterType.IsValueType;
        }
    }
}