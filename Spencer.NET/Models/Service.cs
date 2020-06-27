namespace Spencer.NET
{
    public class Service : IService
    {
        public ServiceFlags Flags { get; set; }

        public IServiceRegistration Registration { get; set; }
        
        public IServiceData Data { get; set; }

        public Service()
        {
            Flags = new ServiceFlags();
        }
    }
}