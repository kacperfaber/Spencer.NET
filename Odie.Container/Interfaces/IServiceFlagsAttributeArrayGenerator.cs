using System;

namespace Odie
{
    public interface IServiceFlagsAttributeArrayGenerator
    {
        ServiceFlagAttribute[] Generate(Type type);
    }
}