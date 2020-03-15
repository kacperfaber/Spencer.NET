using System;
using NUnit.Framework;

namespace Odie.Tests
{
    public class modelbuilder_build_tests
    {
        Model exec(Action<ModelBuilder> act)
        {
            ModelBuilder builder = new ModelBuilder();
            act(builder);

            return builder.Build();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(b => { }));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(b => { }));
        }

        [Test]
        [Ignore("container doesnt work correctly.")]
        public void x()
        {
            ModelBuilder builder = StaticContainer.Current.Resolve<ModelBuilder>();
            
            ModelBuilder newBuilder = builder
                .AddBool("verified")
                .AddBool("registered")
                .AddRange("years_old", 0, 20)
                .AddGuid<string>("id")
                .AddDateTime<string>("date_of_birth", DateTimeKind.PAST);

            Model model = newBuilder.Build();

            ResultGenerator generator = StaticContainer.Current.Resolve<ResultGenerator>();
            Result result = generator.Generate(model);

            Console.WriteLine("begin");
            
            foreach (Field field in result.Fields)
            {
                Console.WriteLine($"{field.Type.Name} {field.Name}: {field.Value}");
            }
        }
    }
}