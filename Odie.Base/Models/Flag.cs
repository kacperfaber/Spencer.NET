namespace Odie
{
    public class Flag
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public bool GetBool()
        {
            return (bool) Value;
        } 

        public string GetString()
        {
            return (string) Value;
        }

        public int GetInt()
        {
            return (int) Value;
        }

        public T GetValue<T>()
        {
            return (T) Value;
        }

        public object GetValue()
        {
            return Value;
        }
    }
}