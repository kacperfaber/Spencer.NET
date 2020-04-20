namespace Spencer.NET
{
    public interface ISingleInstanceChecker
    {
        bool Check(IService service);
    }
}