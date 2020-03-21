using System;
using NUnit.Framework;

namespace Odie.Tests
{
    public class hello_world
    {
        class Garfield
        {
        }

        class Oscar
        {
        }

        class Odie
        {
            public Odie(Garfield garfield, Oscar oscar)
            {
                Console.WriteLine("using ctor garfield, oscar");
            }

            public Odie(string name, string email)
            {
                Console.WriteLine($"using string, string ctor where\nname {name}\nemail {email}");
            }
        }
    }
}