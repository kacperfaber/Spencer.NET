using System;

namespace Odie
{
    public interface IArrayGenerator
    {
        object GenerateArray(Type type);
    }
}