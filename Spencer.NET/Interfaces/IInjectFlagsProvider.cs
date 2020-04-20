using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IInjectFlagsProvider
    {
        IEnumerable<ServiceFlag> ProvideFlags(IService service);
    }
}