using System;
using Odie.Commons;

namespace Odie
{
    // TODO default with value in container. XD
    // attr
    public class BooleanGenerator : IValueGenerator
    {
        public object Generate(object parameters, Type parametersType, Type exceptedType, out Type valueType)
        {
            ServiceLoader.Current.RegisterAssembly(GetType().Assembly);
            ServiceLoader.Current.RegisterAssembly(typeof(RandomGenerator).Assembly);
            
            if (parametersType == typeof(float))
            {
                int p = Convert.ToInt32((float) parameters * 100);

                RandomGenerator random = ServiceLoader.Current.Resolve<RandomGenerator>();
                int result = random.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            else if (parametersType == typeof(int))
            {
                int p = (int) parameters;
                
                RandomGenerator random = ServiceLoader.Current.Resolve<RandomGenerator>();
                int result = random.GenerateInt(0, 100);

                valueType = typeof(bool);
                return result < p;
            }
            
            throw new ArgumentException();
        }
    }
}