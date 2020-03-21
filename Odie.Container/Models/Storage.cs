namespace Odie
{
    public class Storage : IStorage
    {
        public Storage()
        {
            Services = new ServiceList();
            Assemblies = new AssemblyList();
        }
        
        public IServiceList Services { get; set; }
        public IAssemblyList Assemblies { get; set; }
    }
}