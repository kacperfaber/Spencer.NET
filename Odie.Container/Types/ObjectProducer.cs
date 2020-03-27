namespace Odie
{
    public class ObjectProducer : IObjectProducer
    {
        public IServiceInstanceGenerator ServiceInstanceGenerator;
        public IObjectPostProcessor PostProcessor;

        public ObjectProducer(IServiceInstanceGenerator serviceInstanceGenerator, IObjectPostProcessor postProcessor)
        {
            ServiceInstanceGenerator = serviceInstanceGenerator;
            PostProcessor = postProcessor;
        }

        public object ProduceObject(IService service, IContainer container)
        {
            object instance = ServiceInstanceGenerator.GenerateInstance(service, container);

            PostProcessor.Process(instance, service, container);
            
            return instance;
        }
    }
}