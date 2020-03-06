using System.Collections.Generic;

namespace Odie.Engine
{
    public class Model
    {
        public Model()
        {
            Properties = new List<Property>();
        }
        
        public List<Property> Properties { get; set; }
    }
}