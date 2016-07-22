using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class AssocTest
    {
        private Factory f = new Factory();

        [Test()]
        public void construction()
        {
            Assoc a = f.Assoc.assoc("key", "value");
            Assert.AreEqual("key", a.key());
            Assert.AreEqual("value", a.value());
            Assert.AreEqual("key -> value", a.show());
        }

        [Test()]
        public void memeoConstruction()
        {
            Assoc a = f.Assoc.assoc('k', 'v');
            Func1 op = f.onObject("key");
            Assoc b = f.Assoc.memeo(op, a);
            Assert.AreEqual('k', b.value());
        }
    }
}

