namespace Odie
{
    [ContainerDelegate]
    public class ContainerDelegate : IContainerDelegate
    {
        public void Register(ServiceLoader loader)
        {
            loader.RegisterAssemblyTypes(GetType().Assembly);
        }
    }
}