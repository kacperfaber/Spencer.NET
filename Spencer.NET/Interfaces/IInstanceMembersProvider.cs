using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IInstanceMembersProvider
    {
        IEnumerable<IMember> ProvideMembers(IService service);
    }
}