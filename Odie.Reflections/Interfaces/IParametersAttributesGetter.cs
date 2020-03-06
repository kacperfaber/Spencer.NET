using System.Reflection;

namespace Odie.Reflections
{
    public interface IParametersAttributesGetter
    {
        ParametersAttribute[] ProvideAll(MemberInfo member);
    }
}