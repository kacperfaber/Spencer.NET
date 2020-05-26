using System;

namespace Spencer.NET
{
    public class FactoryTypeProvider : IFactoryTypeProvider
    {
        public IAssignableChecker AssignableChecker;

        public FactoryTypeProvider(IAssignableChecker assignableChecker)
        {
            AssignableChecker = assignableChecker;
        }

        public Type ProvideType(Type declarationType, Attribute attribute)
        {
            if (attribute is FactoryResult factoryResult)
            {
                if (AssignableChecker.Check(factoryResult.ResultType, declarationType))
                {
                    return factoryResult.ResultType;
                }
            }

            else if (attribute is FactoryAttribute factoryAttr)
            {
                if (AssignableChecker.Check(factoryAttr.ResultType, declarationType))
                {
                    return factoryAttr.ResultType;
                }
            }

            return declarationType;
        }
    }
}