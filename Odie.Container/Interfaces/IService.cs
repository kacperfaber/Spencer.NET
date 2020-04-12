namespace Odie
{
    public interface IService
    {
        ServiceFlags Flags { get; set; }
        
        IServiceRegistration Registration { get; set; }
        
        IServiceData Data { get; set; }
        
        IServiceInfo Info { get; set; }
    }
}