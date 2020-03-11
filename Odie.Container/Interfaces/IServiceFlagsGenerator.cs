using System;

namespace Odie
{
    public interface IServiceFlagsGenerator
    {
        ServiceFlag GenerateFlags(Type type);
    }
}