using System.Reflection;

namespace Odie
{
    public class ServiceFlag
    {
        public string Name;
        public object Value;
        public IMember Parent;

        public ServiceFlag(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}