namespace Odie
{
    public class ObjectPostProcessor : IObjectPostProcessor
    {
        public IMemberValuesInjector MemberValuesInjector;
        public IInstanceMembersValueInjector InstanceMembersValueInjector;

        public ObjectPostProcessor(IInstanceMembersValueInjector instanceMembersValueInjector, IMemberValuesInjector memberValuesInjector)
        {
            InstanceMembersValueInjector = instanceMembersValueInjector;
            MemberValuesInjector = memberValuesInjector;
        }

        public void Process(object instance, IService service, IReadOnlyContainer container)
        {
            MemberValuesInjector.InjectAll(service, container, instance);
            InstanceMembersValueInjector.InjectAll(service, instance);
        }
    }
}