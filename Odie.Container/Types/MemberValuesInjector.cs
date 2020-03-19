using System.Collections.Generic;

namespace Odie
{
    public class MemberValuesInjector : IMemberValuesInjector
    {
        public IValueProvider ValueProvider;
        public IMemberValueSetter ValueSetter;
        public IInjectFlagsProvider InjectsProvider;

        public MemberValuesInjector(IMemberValueSetter valueSetter, IValueProvider valueProvider, IInjectFlagsProvider injectsProvider)
        {
            ValueSetter = valueSetter;
            ValueProvider = valueProvider;
            InjectsProvider = injectsProvider;
        }

        public void InjectAll(IService service, IContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                object value = ValueProvider.ProvideValue(injectFlag.Parent.ReflectedType, container);
                ValueSetter.SetValue(injectFlag.Parent, instance, value);
            }
        }
    }
}