﻿using System;
using NUnit.Framework;
using Odie.Engine.Builders;

namespace Odie.Engine.Tests
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
            Assert.DoesNotThrow(() => exec(b => {}));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(b => {}));
        }
    }
}