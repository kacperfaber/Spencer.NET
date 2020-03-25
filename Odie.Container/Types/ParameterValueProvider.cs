using System;

namespace Odie
{
    public class ParameterValueProvider : IParameterValueProvider
    {
        public ITypeIsValueTypeChecker IsValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public ITypeIsArrayChecker IsArrayChecker;
        public IArrayGenerator ArrayGenerator;
        public IIsEnumerableChecker IsEnumerableChecker;
        public IEnumerableGenerator EnumerableGenerator;
        public IParameterHasDefaultValueChecker DefaultValueChecker;
        public IParameterInfoDefaultValueProvider DefaultValueProvider;

        public ParameterValueProvider(ITypeIsValueTypeChecker isValueTypeChecker, IValueTypeActivator valueTypeActivator, ITypeIsArrayChecker isArrayChecker, IArrayGenerator arrayGenerator, IIsEnumerableChecker isEnumerableChecker, IEnumerableGenerator enumerableGenerator, IParameterHasDefaultValueChecker defaultValueChecker, IParameterInfoDefaultValueProvider defaultValueProvider)
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

        public object ProvideValue(IParameter parameter, IContainer container)
        {
            if (DefaultValueChecker.Check(parameter))
            {
                return DefaultValueProvider.Provide(parameter);
            }
            
            if (IsValueTypeChecker.Check(parameter.ParameterType))
            {
                return ValueTypeActivator.ActivateInstance(parameter.ParameterType);
            }

            if (IsEnumerableChecker.Check(parameter.ParameterType))
            {
                return EnumerableGenerator.GenerateEnumerable(parameter.ParameterType);
            }
            
            if (IsArrayChecker.Check(parameter.ParameterType))
            {
                return ArrayGenerator.GenerateArray(parameter.ParameterType);
            }

            return container.Resolve(parameter.ParameterType);
        }
    }
}