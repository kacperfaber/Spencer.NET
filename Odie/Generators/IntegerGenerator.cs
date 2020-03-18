using System;

namespace Odie
{
    public class IntegerGenerator : IValueGenerator
    {
        public ITypeChanger TypeChanger;
        public IRandomGenerator RandomGenerator;

        public IntegerGenerator(IRandomGenerator randomGenerator, ITypeChanger typeChanger)
        {
            RandomGenerator = randomGenerator;
            TypeChanger = typeChanger;
        }

        public object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType)
        {
            IntegerParameters @params = TypeChanger.ChangeType<IntegerParameters>(parameters);

            int result = RandomGenerator.GenerateInt(@params.Min, @params.Max);
            valueType = result.GetType();

            return result;
        }
    }
}