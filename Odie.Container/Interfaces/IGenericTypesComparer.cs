using System;

namespace Odie
{
    public interface IGenericTypesComparer
    {
        bool Compare(Type t1, Type t2);
    }
}