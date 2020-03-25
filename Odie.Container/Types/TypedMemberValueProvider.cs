using System;
using System.Reflection;

namespace Odie
{
    public class TypedMemberValueProvider : ITypedMemberValueProvider
    {
        public ITypeIsValueTypeChecker IsValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public ITypeIsArrayChecker IsArrayChecker;
        public IArrayGenerator ArrayGenerator;
        public IIsEnumerableChecker IsEnumerableChecker;
        public IEnumerableGenerator EnumerableGenerator;
        public IParameterHasDefaultValueChecker DefaultValueChecker;
        public IParameterDefaultValueProvider DefaultValueProvider;

        public TypedMemberValueProvider(ITypeIsValueTypeChecker isValueTypeChecker, IValueTypeActivator valueTypeActivator, ITypeIsArrayChecker isArrayChecker, IArrayGenerator arrayGenerator, IIsEnumerableChecker isEnumerableChecker, IEnumerableGenerator enumerableGenerator, IParameterHasDefaultValueChecker defaultValueChecker, IParameterDefaultValueProvider defaultValueProvider)
        {
            IsValueTypeChecker = isValueTypeChecker;
            ValueTypeActivator = valueTypeActivator;
            IsArrayChecker = isArrayChecker;
            ArrayGenerator = arrayGenerator;
            IsEnumerableChecker = isEnumerableChecker;
            EnumerableGenerator = enumerableGenerator;
            DefaultValueChecker = defaultValueChecker;
            DefaultValueProvider = defaultValueProvider;
        }

        public object ProvideValue(ITypedMember member, IContainer container)
        {
            if (member is IParameter parameter)
            {
                if (DefaultValueChecker.Check(parameter))
                {
                    return DefaultValueProvider.Provide(parameter);
                }
            }
            
            if (IsValueTypeChecker.Check(member.Type))
            {
                return ValueTypeActivator.ActivateInstance(member.Type);
            }

            if (IsEnumerableChecker.Check(member.Type))
            {
                return EnumerableGenerator.GenerateEnumerable(member.Type);
            }
            
            if (IsArrayChecker.Check(member.Type))
            {
                return ArrayGenerator.GenerateArray(member.Type);
            }

            container.Register(member.Type);
            return container.Resolve(member.Type);
        }
    }
}