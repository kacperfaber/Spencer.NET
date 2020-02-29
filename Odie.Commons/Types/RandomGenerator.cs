using System;

namespace Odie.Commons
{
    public class RandomGenerator : IRandomGenerator
    {
        public int GenerateInt(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}