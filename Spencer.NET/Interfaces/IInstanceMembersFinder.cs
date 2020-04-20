using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IInstanceMembersFinder
    {
        IEnumerable<IMember> FindMembers(IService service);
    }
}