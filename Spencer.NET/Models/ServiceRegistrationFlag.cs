namespace Spencer.NET
{
    public class ServiceRegistrationFlag
    {
        public ServiceRegistrationFlag(int code, object val)
        {
            Code = code;
            Value = val;
        }

        public int Code { get; set; }

        public object Value { get; set; }
        
        public IMember Member { get; set; }
    }
}