namespace Spencer.NET
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

        public object ProduceObject(IService service, IReadOnlyContainer container)
        {
            object instance = ServiceInstanceGenerator.GenerateInstance(service, container);

            PostProcessor.Process(instance, service, container);
            
            return instance;
        }
    }
}