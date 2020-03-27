namespace Odie
{
    public class StaticContainer
    {
        public static IContainer Current = ContainerFactory.CreateContainer();
    }
}