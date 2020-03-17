using System;

namespace Odie
{
    public class Configuration : FallbackConfiguration
    {
        public override void TypeNotRegistered(Type type, IContainer container)
        {
            container.RegisterAssembly(type.Assembly);
            container.Register(type);
            

            Console.WriteLine("not found " + type.FullName);
            Console.WriteLine("registering type and assembly " + type.Assembly.FullName);
        }
    }
}