using System.Collections.Generic;

namespace Odie
{
    public interface IInstanceMembersFinder
    {
        IEnumerable<IMember> FindMembers(IService service);
    }
}