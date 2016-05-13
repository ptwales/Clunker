using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class AssocTest
    {
        [Test()]
        public void ConstructionTest()
        {
            Assoc a = new Assoc("key", "value");
            Assert.AreEqual("key", a.key());
            Assert.AreEqual("value", a.value());
        }

        [Test()]
        public void OperationalTest()
        {
            Factory f = new Factory();
            Assoc a = new Assoc('k', 'v');
            Applicable op = f.onObject("key");
            Assoc b = new Assoc(op, a);
            Assert.AreEqual('k', b.value());
        }
    }
}

