using System;

namespace Odie
{
    public interface IGenericServiceFinder
    {
        Service FindGenericService(ServicesList list, Type type);
    }
}