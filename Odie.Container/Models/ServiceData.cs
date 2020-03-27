namespace Odie
{
    public class ServiceData : IServiceData
    {
        public bool Initialized { get; set; }
        public object Instance { get; set; }
    }
}