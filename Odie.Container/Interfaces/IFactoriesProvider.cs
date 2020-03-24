using System.Collections.Generic;

namespace Odie
{
    public interface IFactoriesProvider
    {
        IEnumerable<IFactory> ProvideFactories(IService service);
    }
}