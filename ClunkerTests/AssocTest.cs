using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class AssocTest
    {
        private Factory clunk = new Factory();

        [Test()]
        public void construction()
        {
            Assoc a = clunk.Assoc.assoc("key", "value");
            Assert.AreEqual("key", a.key());
            Assert.AreEqual("value", a.value());
            Assert.AreEqual("key -> value", a.show());
        }

        [Test()]
        public void memeoConstruction()
        {
            Assoc a  = clunk.Assoc.assoc('k', 'v');
            Func1 op = clunk.Func1.onObject("key");
            Assoc b  = clunk.Assoc.memeo(op, a);
            Assert.AreEqual('k', b.value());
        }
    }
}

