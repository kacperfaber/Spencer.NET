using System;

namespace Odie
{
    public interface IGenericServiceFinder
    {
        IService FindGenericService(ServicesList list, Type type);
    }
}