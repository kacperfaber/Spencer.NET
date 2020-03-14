using System;

namespace Odie
{
    public interface IServiceResolver
    {
        object Resolve(Service service, IContainer container);
    }
}