using System.Collections.Generic;

namespace Odie
{
    public class InstanceMembersValueInjector : IInstanceMembersValueInjector
    {
        public IInstanceMembersFinder InstanceMembersFinder;
        public IMemberValueSetter MemberValueSetter;

        public InstanceMembersValueInjector(IMemberValueSetter memberValueSetter, IInstanceMembersFinder instanceMembersFinder)
        {
            MemberValueSetter = memberValueSetter;
            InstanceMembersFinder = instanceMembersFinder;
        }

        public void InjectAll(IService service, object instance)
        {
            IEnumerable<IMember> members = InstanceMembersFinder.FindMembers(service);

            foreach (IMember member in members)
            {
                MemberValueSetter.SetValue(member, instance);
            }
        }
    }
}