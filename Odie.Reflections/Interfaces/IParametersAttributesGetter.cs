using System.Reflection;

namespace Odie
{
    public interface IParametersAttributesGetter
    {
        ParametersAttribute[] ProvideAll(MemberInfo member);
    }
}