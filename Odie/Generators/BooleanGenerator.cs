using System;

namespace Odie
{
    public class BooleanGenerator : IValueGenerator
    {
        public IRandomGenerator RandomGenerator;

        public BooleanGenerator(IRandomGenerator randomGenerator)
        {
            RandomGenerator = randomGenerator;
        }

        public object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType)
        {
            if (parametersType == typeof(float))
            {
                int p = Convert.ToInt32((float) parameters * 100);
                int result = RandomGenerator.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            if (parametersType == typeof(int))
            {
                int p = (int) parameters;

                int result = RandomGenerator.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            throw new ArgumentException();
        }
    }
}