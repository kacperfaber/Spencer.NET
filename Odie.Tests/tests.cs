using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Odie.Tests
{
    public class tests
    {
        class Filip
        {
            [Inject]
            public Piotr Piotr { get; set; }

            [Inject]
            public object[] Array;
        }

        class Piotr
        {
            public string LastName = "Tarczynski";
        }

        void exec(int x)
        {
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(0));
        }

        [Test]
        public void test_method()
        {
            IContainer container = StaticContainer.Current;

            Filip filip = container.Resolve<Filip>();

            foreach (string filipToken in filip.Array)
            {
                Console.WriteLine(filipToken);
            }

            Console.WriteLine("end of tokens");
        }
    }
}