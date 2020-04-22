using System;

namespace Spencer.NET
{
    public class InjectException : Exception
    {
        public InjectException(Type typeToInject) : base($"Cannot to Inject type {typeToInject.FullName}")
        {
            
        } 
    }
}