using System;

namespace Odie
{
    public interface IServiceInfoGenerator
    {
        ServiceInfo Generate(Type type);
    }
}