using System;
using Odie.Commons;

namespace Odie
{
    public class BooleanGenerator : IValueGenerator
    {
        public object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType)
        {
            if (parametersType == typeof(float))
            {
                int p = Convert.ToInt32((float) parameters * 100);

                RandomGenerator random = StaticContainer.Current.Resolve<RandomGenerator>();
                int result = random.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            if (parametersType == typeof(int))
            {
                int p = (int) parameters;

                RandomGenerator random = StaticContainer.Current.Resolve<RandomGenerator>();
                int result = random.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            throw new ArgumentException();
        }
    }
}