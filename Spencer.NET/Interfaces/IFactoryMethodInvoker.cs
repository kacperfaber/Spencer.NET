namespace Spencer.NET
{
    public interface IFactoryMethodInvoker
    {
        object InvokeMethod(IFactory factory);
    }
}