using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class MemberValuesInjector : IMemberValuesInjector
    {
        public ITypedMemberValueProvider TypedMemberValueProvider;
        public IMemberValueSetter ValueSetter;
        public IInjectFlagsProvider InjectsProvider;

        public MemberValuesInjector(IMemberValueSetter valueSetter, ITypedMemberValueProvider typedMemberValueProvider, IInjectFlagsProvider injectsProvider)
        {
            ValueSetter = valueSetter;
            TypedMemberValueProvider = typedMemberValueProvider;
            InjectsProvider = injectsProvider;
        }

        public void InjectAll(IService service, IContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                object value = TypedMemberValueProvider.ProvideValue(injectFlag.Parent, container);
                ValueSetter.SetValue(injectFlag.Parent, instance, value);
            }
        }
    }
}