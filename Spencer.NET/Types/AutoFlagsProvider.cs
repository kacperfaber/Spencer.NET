using System.Collections.Generic;

namespace Spencer.NET
{
    public class AutoFlagsProvider : IAutoFlagsProvider
    {
        public IEnumerable<ServiceFlag> ProvideFlags(IService service)
        {
            return service.Flags.GetFlags(ServiceFlagConstants.Auto);
        }
    }
}