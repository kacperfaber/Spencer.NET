namespace Odie
{
    public class AlwaysNewAttribute : ServiceFlagAttribute
    {
        public AlwaysNewAttribute() : base(ServiceFlagConstants.AlwaysNew)
        {
        }
    }
}