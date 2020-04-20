using System;

namespace Spencer.NET
{
    public class FactoryResultTypeGenerator : IFactoryResultTypeGenerator
    {
        public IFactoryResultExistChecker ResultExistChecker;
        public IFactoryResultTypeProvider ResultTypeProvider;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IAssignableChecker AssignableChecker;

        public FactoryResultTypeGenerator(IFactoryResultExistChecker resultExistChecker, IFactoryResultTypeProvider resultTypeProvider, IMemberDeclarationTypeProvider declarationTypeProvider, IAssignableChecker assignableChecker)
        {
            ResultExistChecker = resultExistChecker;
            ResultTypeProvider = resultTypeProvider;
            DeclarationTypeProvider = declarationTypeProvider;
            AssignableChecker = assignableChecker;
        }

        public Type GenerateResultType(IMember member)
        {
            Type returnType = DeclarationTypeProvider.ProvideDeclarartionType(member);

            if (ResultExistChecker.Check(member))
            {
                Type resultType = ResultTypeProvider.ProvideResultType(member);

                if (AssignableChecker.Check(resultType, returnType))
                {
                    return resultType;
                }
            }

            return returnType;
        }
    }
}