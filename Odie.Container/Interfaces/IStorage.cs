namespace Odie
{
    public interface IStorage
    {
        IServiceList Services { get; set; }
        
        IAssemblyList Assemblies { get; set; }
    }
}