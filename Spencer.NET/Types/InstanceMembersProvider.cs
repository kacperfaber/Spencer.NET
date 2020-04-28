using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class InstanceMembersProvider : IInstanceMembersProvider
    {
        public IEnumerable<IMember> ProvideMembers(ServiceFlags serviceFlags)
        {
            return Array.ConvertAll(serviceFlags.GetFlags(ServiceFlagConstants.Instance).ToArray(), x => x.Member);
        }
    }
}