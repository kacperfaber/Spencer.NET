using System;

namespace Spencer.NET
{
    public interface IServiceFlagsGenerator
    {
        ServiceFlags GenerateFlags(Type type);
    }
}