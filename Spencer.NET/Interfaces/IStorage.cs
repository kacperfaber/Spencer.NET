namespace Spencer.NET
{
    public interface IStorage
    {
        IServiceList Services { get; set; }
        
        IAssemblyList Assemblies { get; set; }
    }
}