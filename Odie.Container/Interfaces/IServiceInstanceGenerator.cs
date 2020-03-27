using System;

namespace Odie
{
    public interface IServiceInstanceGenerator
    {
        object GenerateInstance(IService service, IContainer container);
    }
}