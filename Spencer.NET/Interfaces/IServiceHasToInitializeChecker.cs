namespace Spencer.NET
{
    public interface IServiceHasToInitializeChecker
    {
        bool Check(IService service);
    }
}