using System;

namespace Odie
{
    public class ServiceGenerator
    {
        public Service Generate(Type type)
        {
            Service service = new Service()
            {
                Assembly = type.Assembly,
                Attributes = Attribute.GetCustomAttributes(type)
            }; // todo
        }
    }
}