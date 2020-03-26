using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class InstanceMembersFinder : IInstanceMembersFinder
    {
        public IEnumerable<IMember> FindMembers(IService service)
        {
            return Array.ConvertAll(service.Flags
                .GetFlags(ServiceFlagConstants.Instance).ToArray(), x => x.Parent);
        }
    }
}