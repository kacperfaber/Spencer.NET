using System.Collections.Generic;

namespace Odie
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