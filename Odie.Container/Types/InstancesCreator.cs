using System;

namespace Odie
{
    public class InstancesCreator
    {
        public static InstancesCreator Current = new InstancesCreator();
        
        public object CreateInstance(Type type)
        {
            
        }
    }
}