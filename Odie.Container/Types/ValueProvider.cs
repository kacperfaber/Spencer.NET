using System;

namespace Odie
{
    public class ValueProvider : IValueProvider
    {
        public ITypeIsValueTypeChecker IsValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public ITypeIsArrayChecker IsArrayChecker;
        public IArrayGenerator ArrayGenerator;
        public IIsEnumerableChecker IsEnumerableChecker;
        public IEnumerableGenerator EnumerableGenerator;

        public ValueProvider(ITypeIsValueTypeChecker isValueTypeChecker, IValueTypeActivator valueTypeActivator, ITypeIsArrayChecker isArrayChecker, IArrayGenerator arrayGenerator, IIsEnumerableChecker isEnumerableChecker, IEnumerableGenerator enumerableGenerator)
        {
            IsValueTypeChecker = isValueTypeChecker;
            ValueTypeActivator = valueTypeActivator;
            IsArrayChecker = isArrayChecker;
            ArrayGenerator = arrayGenerator;
            IsEnumerableChecker = isEnumerableChecker;
            EnumerableGenerator = enumerableGenerator;
        }

        public object ProvideValue(Type exceptedType, IContainer container)
        {
            if (IsValueTypeChecker.Check(exceptedType))
            {
                return ValueTypeActivator.ActivateInstance(exceptedType);
            }

            if (IsEnumerableChecker.Check(exceptedType))
            {
                return EnumerableGenerator.GenerateEnumerable(exceptedType);
            }
            
            if (IsArrayChecker.Check(exceptedType))
            {
                return ArrayGenerator.GenerateArray(exceptedType);
            }

            return container.Resolve(exceptedType);
        }
    }
}