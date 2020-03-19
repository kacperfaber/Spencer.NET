using System.Collections.Generic;

namespace Odie
{
    public class MemberValuesInjector : IMemberValuesInjector
    {
        public IValueProvider ValueProvider;
        public IMemberValueSetter ValueSetter;
        
        public void InjectAll(IService service, IContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = service.Flags.GetFlags(ServiceFlagConstants.Inject);

            foreach (ServiceFlag injectFlag in injections)
            {
                object value = ValueProvider.ProvideValue(injectFlag.Parent.ReflectedType, container);
                ValueSetter.SetValue(injectFlag.Parent, instance, value);
            }
        }
    }
}