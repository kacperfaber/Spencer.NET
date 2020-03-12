using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFlags : List<ServiceFlag>
    {
        public bool HasFlag(string name)
        {
            return this.SingleOrDefault(x => x.Name == name) != null;
        }

        public bool HasFlag(ServiceFlag flag)
        {
            return this.SingleOrDefault(x => x == flag) != null;
        }
    }
}