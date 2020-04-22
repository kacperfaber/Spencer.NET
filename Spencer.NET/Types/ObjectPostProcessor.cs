namespace Spencer.NET
{
    public class ObjectPostProcessor : IObjectPostProcessor
    {
        public IInjectMemberValuesInjector InjectMemberValuesInjector;
        public IInstanceMembersValueInjector InstanceMembersValueInjector;
        public IAutoMemberValuesInjector AutoMemberValuesInjector;
        public ITryInjectMemberValuesInjector TryInjectMemberValuesInjector;
        
        public ObjectPostProcessor(IInstanceMembersValueInjector instanceMembersValueInjector, IInjectMemberValuesInjector injectMemberValuesInjector, ITryInjectMemberValuesInjector tryInjectMemberValuesInjector)
        {
            InstanceMembersValueInjector = instanceMembersValueInjector;
            InjectMemberValuesInjector = injectMemberValuesInjector;
            TryInjectMemberValuesInjector = tryInjectMemberValuesInjector;
        }

        public void Process(object instance, IService service, IReadOnlyContainer container)
        {
            InjectMemberValuesInjector.InjectAll(service, container, instance);
            TryInjectMemberValuesInjector.InjectAll(service, container, instance);
            InstanceMembersValueInjector.InjectAll(service, instance);
        }
    }
}