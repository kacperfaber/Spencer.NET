using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class ArrayGenerator : IValueGenerator
    {
        public object[] Values;
        
        public ArrayGenerator(object[] values)
        {
            Values = values;
        }
        
        public virtual object Generate(object parameters, Type parametersType, Type exceptedType, out Type valueType)
        {
            if (parametersType == typeof(int))
            {
                List<object> items = new List<object>();

                for (int i = 0; i < (int) parameters; i++)
                {
                    items.Add(GetItem());
                }

                valueType = items.GetType();
                return items;
            }

            throw new NotImplementedException();
        }

        private object GetItem()
        {
            RandomGenerator generator = ServiceLoader.Current.Resolve<RandomGenerator>();
            int index = generator.GenerateInt(0, Values.Length);

            return Values[index];
        }
    }
}