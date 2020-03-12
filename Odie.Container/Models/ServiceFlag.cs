namespace Odie
{
    public class ServiceFlag
    {
        public string Name;
        public object Value;

        public ServiceFlag(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}