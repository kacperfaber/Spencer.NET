using System;

namespace Odie
{
    public class FlagAttributeTypeProvider : IFlagAttributeTypeProvider
    {
        public Type ProvideType()
        {
            return typeof(FlagAttribute);
        }
    }
}