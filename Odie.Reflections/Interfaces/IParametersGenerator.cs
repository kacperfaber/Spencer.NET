using System.Reflection;

namespace Odie
{
    public interface IParametersGenerator
    {
        Parameters GenerateParameters(MemberInfo member);
    }
}