using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    using Tuple = Clunker.Tuple;

    [TestFixture()]
    public class TupleTest
    {
        Factory f = new Factory();

        [Test()]
        public void emptyTuple()
        {
            Tuple t = f.pack();
            Assert.AreEqual(0, t.size());
            Assert.AreEqual(0, t.explode().Length);
        }

        [Test()]
        public void singleTuple()
        {
            Tuple t = f.pack(13);
            Assert.AreEqual(1, t.size());
            Assert.AreEqual(13, t.item(0));
            Assert.AreEqual(new object[] { 13 }, t.explode());
        }

        [Test()]
        public void singleUnpack()
        {
            Tuple t = f.pack(13);
          
            object[] target = new object[1] { 0 };
            t.unpack(target);

            Assert.AreEqual(new object[] { 13 }, target);
            Assert.AreEqual(target[0], t.item(0));
        }
    }
}

