using System;

namespace Odie
{
    public class FlagGenerator : IFlagGenerator
    {
        public Flag GenerateFlag(Attribute attribute)
        {
            FlagAttribute flagAttr = (FlagAttribute) attribute;

            return new Flag()
            {
                Name = flagAttr.Name,
                Value = flagAttr.Value
            };
        }

        public Flag GenerateFlag(FlagAttribute attribute)
        {
            return new Flag()
            {
                Name = attribute.Name,
                Value = attribute.Value
            };
        }
    }
}