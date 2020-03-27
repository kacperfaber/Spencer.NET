namespace Odie
{
    public interface IServiceData
    {
        bool Initialized { get; set; }
        
        object Instance { get; set; }
    }
}