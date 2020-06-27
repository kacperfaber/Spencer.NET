using System;

namespace Spencer.NET
{
    public interface IServiceResolver
    {
        object Resolve(IService service, IContainer container);
    }
}