using System.Reflection;

namespace Odie
{
    public class ParametersGenerator : IParametersGenerator
    {
        public IParametersAttributesGetter AttributesGetter;
        
        public Parameters GenerateParameters(MemberInfo member)
        {
            ParametersAttribute[] attributes = AttributesGetter.ProvideAll(member);
            
            
        }
    }
}