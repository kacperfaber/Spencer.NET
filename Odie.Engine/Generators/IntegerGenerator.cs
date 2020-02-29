using System;
using Odie.Commons;

namespace Odie.Engine
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

        public object Generate(object parameters, Type parametersType, Type exceptedType)
        {
            IntegerParameters @params = TypeChanger.ChangeType<IntegerParameters>(parameters);

            return RandomGenerator.GenerateInt(@params.Min, @params.Max);
        }
    }
}