using System;

namespace Spencer.NET
{
    public interface IGenericTypesComparer
    {
        bool Compare(Type t1, Type t2);
    }
}