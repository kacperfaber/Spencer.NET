using System;

namespace Odie
{
    public interface IInstanceGenerator
    {
        object GenerateInstance(Type type, ServiceFlags flags);
    }
}