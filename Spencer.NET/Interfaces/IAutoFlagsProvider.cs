using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IAutoFlagsProvider
    {
        IEnumerable<ServiceFlag> ProvideFlags(IService service);
    }
}