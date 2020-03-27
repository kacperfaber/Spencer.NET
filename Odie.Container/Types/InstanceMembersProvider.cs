using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class InstanceMembersProvider : IInstanceMembersProvider
    {
        public IEnumerable<IMember> ProvideMembers(IService service)
        {
            return Array.ConvertAll(service.Flags.GetFlags(ServiceFlagConstants.Instance).ToArray(), x => x.Member);
        }
    }
}