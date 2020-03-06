using System;
using Odie.Engine.Attributes;

namespace Odie.Engine
{
    public class ParametersAttributeTypeProvider : IParametersAttributeTypeProvider
    {
        public Type ProvideType() => typeof(ParametersAttribute);
    }
}