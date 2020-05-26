using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class FactoryResultTypeGenerator : IFactoryResultTypeGenerator
    {
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IAttributesFinder AttributesFinder;
        public IFactoryResultAttributeProvider FactoryResultAttributeProvider;
        public IFactoryTypeProvider FactoryTypeProvider;

        public FactoryResultTypeGenerator(IFactoryTypeProvider factoryTypeProvider, IFactoryResultAttributeProvider factoryResultAttributeProvider, IAttributesFinder attributesFinder, IMemberDeclarationTypeProvider declarationTypeProvider)
        {
            FactoryTypeProvider = factoryTypeProvider;
            FactoryResultAttributeProvider = factoryResultAttributeProvider;
            AttributesFinder = attributesFinder;
            DeclarationTypeProvider = declarationTypeProvider;
        }

        public Type GenerateResultType(IMember member)
        {
            Type declarationType = DeclarationTypeProvider.ProvideDeclarartionType(member);
            IEnumerable<Attribute> attributes = AttributesFinder.FindAttributes<Attribute>(member);
            Attribute attr = FactoryResultAttributeProvider.ProvideAttributeOrNull(attributes);

            if (attr == null)
            {
                return declarationType;
            }

            return FactoryTypeProvider.ProvideType(declarationType, attr);
        }
    }
}