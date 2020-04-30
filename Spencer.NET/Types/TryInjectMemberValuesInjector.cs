using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class TryInjectMemberValuesInjector : ITryInjectMemberValuesInjector
    {
        public IServiceAttributeProvider ServiceAttributeFinder;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IMemberValueSetter ValueSetter;
        public IInjectValueProvider InjectValueProvider;

        public TryInjectMemberValuesInjector(IServiceAttributeProvider serviceAttributeFinder, IMemberDeclarationTypeProvider declarationTypeProvider, IMemberValueSetter valueSetter, IInjectValueProvider injectValueProvider)
        {
            ServiceAttributeFinder = serviceAttributeFinder;
            DeclarationTypeProvider = declarationTypeProvider;
            ValueSetter = valueSetter;
            InjectValueProvider = injectValueProvider;
        }

        public void InjectAll(IService service, IReadOnlyContainer container, object instance)
        {
            IEnumerable<ServiceFlag> flags = ServiceAttributeFinder.ProvideFlags(service.Flags, ServiceFlagConstants.TryInject);

            foreach (ServiceFlag flag in flags)
            {
                Type declarationType = DeclarationTypeProvider.ProvideDeclarartionType(flag.Member);
                object value = InjectValueProvider.ProvideValue(declarationType, container);
                
                ValueSetter.SetValue(flag.Member, instance, value);
            }
        }
    }
}