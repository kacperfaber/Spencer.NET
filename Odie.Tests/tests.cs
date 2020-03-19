using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Odie.Tests
{
    public class tests
    {
        interface IK
        {
            string Name { get; set; }
        }

        class Kasia : IK
        {
            public string Name { get; set; } = "Kasia";
        }

        class Basia : IK
        {
            public string Name { get; set; } = "Basia";
        }

        [Test]
        public void test()
        {
            IContainer container = StaticContainer.Current;

            container.RegisterAssembly(GetType().Assembly);

            List<IK> list = new List<IK>(container.ResolveMany<IK>());

            foreach (IK ik in list)
            {
                Console.WriteLine($"target name is {ik} ({ik.GetType().FullName})");
            }
        }
    }
}