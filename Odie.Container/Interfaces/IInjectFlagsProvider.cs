using System.Collections.Generic;

namespace Odie
{
    public interface IInjectFlagsProvider
    {
        IEnumerable<ServiceFlag> ProvideFlags(IService service);
    }
}