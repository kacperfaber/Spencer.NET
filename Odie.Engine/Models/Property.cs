using System;

namespace Odie.Engine
{
    public class Property
    {
        public string Name { get; set; }
        
        public Type ExceptedType { get; set; }

        public IGenerator Generator { get; set; }

        public GeneratorParameters GeneratorParameters { get; set; }
    }
}