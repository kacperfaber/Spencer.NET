using System;

namespace Spencer.NET
{
    public class AutoValueGenerator : IAutoValueGenerator
    {
        public IIsEnumerableChecker IsEnumerableChecker;
        public IEnumerableGenerator EnumerableGenerator;
        public ITypeIsArrayChecker IsArrayChecker;
        public IArrayGenerator ArrayGenerator;
        public ITypeIsValueTypeChecker IsValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;

        public AutoValueGenerator(IIsEnumerableChecker isEnumerableChecker, IEnumerableGenerator enumerableGenerator, ITypeIsArrayChecker isArrayChecker, IArrayGenerator arrayGenerator, ITypeIsValueTypeChecker isValueTypeChecker, IValueTypeActivator valueTypeActivator)
        {
            IsEnumerableChecker = isEnumerableChecker;
            EnumerableGenerator = enumerableGenerator;
            IsArrayChecker = isArrayChecker;
            ArrayGenerator = arrayGenerator;
            IsValueTypeChecker = isValueTypeChecker;
            ValueTypeActivator = valueTypeActivator;
        }

        public object GenerateValue(Type exceptedType)
        {
            if (IsEnumerableChecker.Check(exceptedType))
            {
                return EnumerableGenerator.GenerateEnumerable(exceptedType);
            } 
            
            else if (IsArrayChecker.Check(exceptedType))
            {
                return ArrayGenerator.GenerateArray(exceptedType);
            }
            
            else if (IsValueTypeChecker.Check(exceptedType))
            {
                return ValueTypeActivator.ActivateInstance(exceptedType);
            }
            
            throw new AutoException(exceptedType);
            
            // TODO
            // IF REFERENCE_TYPE
            //     RETURN NEW REFERENCE_TYPE
        }
    }
}