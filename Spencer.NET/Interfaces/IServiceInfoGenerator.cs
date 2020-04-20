using System;

namespace Spencer.NET
{
    public interface IServiceInfoGenerator
    {
        ServiceInfo Generate(Type type);
    }
}