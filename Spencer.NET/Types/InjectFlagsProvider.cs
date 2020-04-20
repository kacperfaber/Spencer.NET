using System.Collections.Generic;

namespace Spencer.NET
{
    public class InjectFlagsProvider : IInjectFlagsProvider
    {
        public IEnumerable<ServiceFlag> ProvideFlags(IService service)
        {
            return service.Flags.GetFlags(ServiceFlagConstants.Inject);
        }
    }
}