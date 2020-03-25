using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class MemberValuesInjector : IMemberValuesInjector
    {
        public IParameterValueProvider ParameterValueProvider;
        public IMemberValueSetter ValueSetter;
        public IInjectFlagsProvider InjectsProvider;

        public MemberValuesInjector(IMemberValueSetter valueSetter, IParameterValueProvider parameterValueProvider, IInjectFlagsProvider injectsProvider)
        {
            ValueSetter = valueSetter;
            ParameterValueProvider = parameterValueProvider;
            InjectsProvider = injectsProvider;
        }

        public void InjectAll(IService service, IContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                object value = ParameterValueProvider.ProvideValue(null, container); // TODO TODO TODO
                ValueSetter.SetValue(injectFlag.Parent, instance, value);
            }
        }
    }
}