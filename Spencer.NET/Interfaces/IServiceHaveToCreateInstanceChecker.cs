namespace Spencer.NET
{
    public interface IServiceHaveToCreateInstanceChecker
    {
        bool Check(IService service);
    }
}