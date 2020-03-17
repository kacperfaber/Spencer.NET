using System;

namespace Odie.Commons
{
    public interface IImplementationsFinder
    {
        Type[] FindImplementations(Type @interface);
    }
}