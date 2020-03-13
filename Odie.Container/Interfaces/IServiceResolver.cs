using System;

namespace Odie
{
    public interface IServiceResolver
    {
        object Resolve(Service service, IContainerResolver resolver, IContainerRegistrar registrar);
    }
}