using System.Reflection;

namespace Odie
{
    public class ParameterHasDefaultValueChecker : IParameterHasDefaultValueChecker
    {
        public bool Check(IParameter parameter)
        {
            return parameter.HasDefaultValue;
        }
    }
}