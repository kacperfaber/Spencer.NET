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
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;

        public MemberValuesInjector(IMemberValueSetter valueSetter, ITypedMemberValueProvider typedMemberValueProvider, IInjectFlagsProvider injectsProvider, IMemberDeclarationTypeProvider declarationTypeProvider)
        {
            ValueSetter = valueSetter;
            TypedMemberValueProvider = typedMemberValueProvider;
            InjectsProvider = injectsProvider;
            DeclarationTypeProvider = declarationTypeProvider;
        }

        public void InjectAll(IService service, IContainer container, object instance)
        {
            IEnumerable<ServiceFlag> injections = InjectsProvider.ProvideFlags(service);

            foreach (ServiceFlag injectFlag in injections)
            {
                Type type = DeclarationTypeProvider.ProvideDeclarartionType(injectFlag.Member);
                object value = TypedMemberValueProvider.ProvideValue(type, container);
                ValueSetter.SetValue(injectFlag.Member, instance, value);
            }
        }
    }
}