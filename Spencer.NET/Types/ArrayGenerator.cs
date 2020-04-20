using System;

namespace Spencer.NET
{
    public class ArrayGenerator : IArrayGenerator
    {
        public object GenerateArray(Type type)
        {
            return Array.CreateInstance(type, 0);
        }
    }
}