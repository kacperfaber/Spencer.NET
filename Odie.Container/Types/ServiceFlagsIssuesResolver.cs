namespace Odie
{
    public class ServiceFlagsIssuesResolver : IServiceFlagsIssuesResolver
    {
        public void ResolveIssues(ServiceFlags flags)
        {
            // add resolving probles with multiple creation methods like ctors and factors later TODO
            
            if (flags.HasFlag(ServiceFlagConstants.MultiInstance) && flags.HasFlag(ServiceFlagConstants.SingleInstance))
            {
                flags.RemoveFlag(ServiceFlagConstants.MultiInstance);
            }

            if (!flags.HasFlag(ServiceFlagConstants.MultiInstance) && !flags.HasFlag(ServiceFlagConstants.SingleInstance))
            {
                flags.AddFlag(ServiceFlagConstants.SingleInstance, null);
            }
        }
    }
}