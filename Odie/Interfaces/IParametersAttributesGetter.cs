using System.Reflection;
using Odie.Engine.Attributes;

namespace Odie.Engine
{
    public interface IParametersAttributesGetter
    {
        ParametersAttribute[] ProvideAll(MemberInfo member);
    }
}