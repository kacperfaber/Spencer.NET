using System;

namespace Odie
{
    public interface IServiceResolver
    {
        object Resolve(IService service, IContainer container);
    }
}