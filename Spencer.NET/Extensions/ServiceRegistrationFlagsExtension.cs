using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET.Extensions
{
    public static class ServiceRegistrationFlagsExtension
    {
        public static bool Has(this IEnumerable<ServiceRegistrationFlag> flags, int code)
        {
            return flags.Any(x => x.Code == code);
        }

        public static ServiceRegistrationFlag SelectFlag(this IEnumerable<ServiceRegistrationFlag> flags, int code)
        {
            return flags.SingleOrDefault(x => x.Code == code);
        }
        
        public static T SelectValueOrNull<T>(this IEnumerable<ServiceRegistrationFlag> flags, int code) where T : class
        {
            return flags.SingleOrDefault(x => x.Code == code).Value as T;
        }
    }
}