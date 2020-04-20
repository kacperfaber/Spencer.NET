namespace Spencer.NET
{
    public class ServiceInfo : IServiceInfo
    {
        public bool IsClass { get; set; }
        
        public bool IsInterface { get; set; }
        
        // todo wtf. How registered class can be interface. TARGET TYPE ALWATYS CLASS
    }
}