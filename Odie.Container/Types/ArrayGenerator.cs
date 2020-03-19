using System;

namespace Odie
{
    public class ArrayGenerator : IArrayGenerator
    {
        public object GenerateArray(Type type)
        {
            return Array.CreateInstance(type, 0);
        }
    }
}