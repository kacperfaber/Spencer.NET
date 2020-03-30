using System;
using System.Reflection;
using Odie.Exceptions;

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

        public object ProvideValue(Type type, IReadOnlyContainer container)
        {
            if (IsValueTypeChecker.Check(type))
            {
                return ValueTypeActivator.ActivateInstance(type);
            }

            if (IsEnumerableChecker.Check(type))
            {
                return EnumerableGenerator.GenerateEnumerable(type);
            }
            
            if (IsArrayChecker.Check(type))
            {
                return ArrayGenerator.GenerateArray(type);
            }
            
            return container.Resolve(type);
        }
    }
}