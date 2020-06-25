using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistrationFlagOptymalizer
    {
        IEnumerable<ServiceRegistrationFlag> Optymalize(IEnumerable<ServiceRegistrationFlag> flags);
    }
}