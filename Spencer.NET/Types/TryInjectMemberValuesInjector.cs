using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class TryInjectMemberValuesInjector : ITryInjectMemberValuesInjector
    {
        public IServiceAttributeProvider ServiceAttributeFinder;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public ITypedMemberValueProvider TypedMemberValueProvider;
        public IMemberValueSetter ValueSetter;

        public TryInjectMemberValuesInjector(IServiceAttributeProvider serviceAttributeFinder, IMemberDeclarationTypeProvider declarationTypeProvider, ITypedMemberValueProvider typedMemberValueProvider, IMemberValueSetter valueSetter)
        {
            ServiceAttributeFinder = serviceAttributeFinder;
            DeclarationTypeProvider = declarationTypeProvider;
            TypedMemberValueProvider = typedMemberValueProvider;
            ValueSetter = valueSetter;
        }

        public void InjectAll(IService service, IReadOnlyContainer container, object instance)
        {
            IEnumerable<ServiceFlag> flags = ServiceAttributeFinder.ProvideFlags(service.Flags, ServiceFlagConstants.TryInject);

            foreach (ServiceFlag flag in flags)
            {
                Type declarationType = DeclarationTypeProvider.ProvideDeclarartionType(flag.Member);
                object value = TypedMemberValueProvider.ProvideValue(declarationType, container);
                
                ValueSetter.SetValue(flag.Member, instance, value);
            }
        }
    }
}