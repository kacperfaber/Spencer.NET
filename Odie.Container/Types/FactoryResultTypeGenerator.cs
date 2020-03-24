using System;
using System.Reflection;

namespace Odie
{
    public class FactoryResultTypeGenerator : IFactoryResultTypeGenerator
    {
        public IFactoryResultExistChecker ResultExistChecker;
        public IFactoryResultResultTypeProvider ResultTypeProvider;
        public IMemberDeclarationTypeProvider DeclarationTypeProvider;
        public IAssignableChecker AssignableChecker;
        
        public Type GenerateResultType(MemberInfo member)
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