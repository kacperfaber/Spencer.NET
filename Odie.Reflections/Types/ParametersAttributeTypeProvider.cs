using System;

namespace Odie
{
    public class ParametersAttributeTypeProvider : IParametersAttributeTypeProvider
    {
        public Type ProvideType() => typeof(ParametersAttribute);
    }
}