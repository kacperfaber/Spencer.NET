using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class InjectMemberValuesInjector : IInjectMemberValuesInjector
    {
        public ITypedMemberValueProvider TypedMemberValueProvider;
        public IMemberValueSetter ValueSetter;
        public IInjectFlagsProvider InjectsProvider;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;

        public InjectMemberValuesInjector(IMemberValueSetter valueSetter, ITypedMemberValueProvider typedMemberValueProvider, IInjectFlagsProvider injectsProvider, IMemberDeclarationTypeProvider declarationTypeProvider)
        {
            ValueSetter = valueSetter;
            TypedMemberValueProvider = typedMemberValueProvider;
            InjectsProvider = injectsProvider;
            DeclarationTypeProvider = declarationTypeProvider;
        }

        public void InjectAll(IService service, IReadOnlyContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                Type type = DeclarationTypeProvider.ProvideDeclarartionType(injectFlag.Member);
                object value = TypedMemberValueProvider.ProvideValue(type, container);

                if (value == null)
                {
                    throw new InjectException(type);
                }
                
                ValueSetter.SetValue(injectFlag.Member, instance, value);
            }
        }
    }
}