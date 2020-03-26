using System.Collections.Generic;

namespace Odie
{
    public interface IInstanceMembersProvider
    {
        IEnumerable<IMember> ProvideMembers(IService service);
    }
}