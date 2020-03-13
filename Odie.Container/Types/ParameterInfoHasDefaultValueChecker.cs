using System.Reflection;

namespace Odie
{
    public class ParameterInfoHasDefaultValueChecker : IParameterInfoHasDefaultValueChecker
    {
        public bool Check(ParameterInfo parameter)
        {
            return parameter.HasDefaultValue;
        }
    }
}