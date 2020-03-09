using System;
using System.ComponentModel;

namespace Odie
{
    [ContainerDelegate]
    public class ContainerDelegate : IContainerDelegate
    {
        public void Register(ServiceLoader loader)
        {
            Console.WriteLine("registering Odie types.");
            
            loader.RegisterAssemblyTypes(GetType().Assembly);
        }
    }
}