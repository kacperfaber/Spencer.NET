using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class AutoMemberValuesInjector : IAutoMemberValuesInjector
    {
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IServiceAttributeProvider ServiceAttributeProvider;
        public IAutoValueGenerator AutoValueGenerator;
        public IMemberValueSetter MemberValueSetter;

        public AutoMemberValuesInjector(IMemberDeclarationTypeProvider declarationTypeProvider, IServiceAttributeProvider serviceAttributeProvider, IAutoValueGenerator autoValueGenerator, IMemberValueSetter memberValueSetter)
        {
            DeclarationTypeProvider = declarationTypeProvider;
            ServiceAttributeProvider = serviceAttributeProvider;
            AutoValueGenerator = autoValueGenerator;
            MemberValueSetter = memberValueSetter;
        }

        public void InjectAll(IService service, object instance)
        {
            IEnumerable<ServiceFlag> flags = ServiceAttributeProvider.ProvideFlags(service.Flags, ServiceFlagConstants.Auto);

            foreach (ServiceFlag flag in flags)
            {
                Type declarationType = DeclarationTypeProvider.ProvideDeclarartionType(flag.Member);
                object value = AutoValueGenerator.GenerateValue(declarationType);

                MemberValueSetter.SetValue(flag.Member, instance, value);
            }
        }
    }
}