using System;

namespace Odie.Reflections
{
    public class ParametersAttributeTypeProvider : IParametersAttributeTypeProvider
    {
        public Type ProvideType() => typeof(ParametersAttribute);
    }
}