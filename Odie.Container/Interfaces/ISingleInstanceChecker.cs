namespace Odie
{
    public interface ISingleInstanceChecker
    {
        bool Check(IService service);
    }
}