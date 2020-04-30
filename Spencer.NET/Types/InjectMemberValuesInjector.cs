using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class InjectMemberValuesInjector : IInjectMemberValuesInjector
    {
        public IMemberValueSetter ValueSetter;
        public IInjectFlagsProvider InjectsProvider;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IInjectValueProvider InjectValueProvider;
        
        public InjectMemberValuesInjector(IMemberValueSetter valueSetter, IInjectFlagsProvider injectsProvider, IMemberDeclarationTypeProvider declarationTypeProvider, IInjectValueProvider injectValueProvider)
        {
            ValueSetter = valueSetter;
            InjectsProvider = injectsProvider;
            DeclarationTypeProvider = declarationTypeProvider;
            InjectValueProvider = injectValueProvider;
        }

        public void InjectAll(IService service, IReadOnlyContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                Type type = DeclarationTypeProvider.ProvideDeclarartionType(injectFlag.Member);
                object value = InjectValueProvider.ProvideValue(type, container); 

                if (value == null)
                {
                    throw new InjectException(type);
                }
                
                ValueSetter.SetValue(injectFlag.Member, instance, value);
            }
        }
    }
}