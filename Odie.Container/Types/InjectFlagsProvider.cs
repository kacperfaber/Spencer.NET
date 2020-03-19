using System.Collections.Generic;

namespace Odie
{
    public class InjectFlagsProvider : IInjectFlagsProvider
    {
        public IEnumerable<ServiceFlag> ProvideFlags(IService service)
        {
            return service.Flags.GetFlags(ServiceFlagConstants.Inject);
        }
    }
}