using System.Collections.Generic;
using System.Reflection;

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
                object value = ValueProvider.ProvideValue(injectFlag.Parent.MemberType == MemberTypes.Property ? ((PropertyInfo) injectFlag.Parent).PropertyType : ((FieldInfo) injectFlag.Parent).FieldType, container);
                ValueSetter.SetValue(injectFlag.Parent, instance, value);
            }
        }
    }
}