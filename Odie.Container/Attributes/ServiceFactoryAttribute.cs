using System.Reflection;

namespace Odie
{
    public class ServiceFactoryAttribute : ServiceFlagAttribute
    {
        public ServiceFactoryAttribute() : base(ServiceFlagConstants.ServiceFactory)
        {
        }
    }
}