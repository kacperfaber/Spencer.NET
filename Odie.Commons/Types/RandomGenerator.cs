using System;

namespace Odie
{
    public class RandomGenerator : IRandomGenerator
    {
        public int GenerateInt(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}