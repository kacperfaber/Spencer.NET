namespace Spencer.NET
{
    public interface IServiceData
    {
        bool Initialized { get; set; }
        
        object Instance { get; set; }
    }
}