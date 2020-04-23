namespace Spencer.NET
{
    public interface IAutoMemberValuesInjector
    {
        void InjectAll(IService service, object instance);
    }
}