using System;

namespace Odie
{
    public interface IFlagGenerator
    {
        Flag GenerateFlag(Attribute attribute);

        Flag GenerateFlag(FlagAttribute attribute);
    }
}