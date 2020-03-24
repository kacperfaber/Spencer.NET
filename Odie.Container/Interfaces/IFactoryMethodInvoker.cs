namespace Odie
{
    public interface IFactoryMethodInvoker
    {
        object InvokeMethod(IFactory factory);
    }
}