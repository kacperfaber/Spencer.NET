using System;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class ParametersAttributeGetter : IParametersAttributesGetter
    {
        public IParametersAttributeTypeProvider TypeProvider;
        public IArrayTypeChanger ArrayTypeChanger;

        public ParametersAttributeGetter(IArrayTypeChanger arrayTypeChanger, IParametersAttributeTypeProvider typeProvider)
        {
            ArrayTypeChanger = arrayTypeChanger;
            TypeProvider = typeProvider;
        }

        public ParametersAttribute[] ProvideAll(MemberInfo member)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(member, TypeProvider.ProvideType());

            return ArrayTypeChanger.ChangeType<ParametersAttribute>(attributes);
        }
    }
}