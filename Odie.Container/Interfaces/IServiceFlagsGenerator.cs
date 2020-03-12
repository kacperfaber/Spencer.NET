using System;

namespace Odie
{
    public interface IServiceFlagsGenerator
    {
        ServiceFlags GenerateFlags(Type type);
    }
}