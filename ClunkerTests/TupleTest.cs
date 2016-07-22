using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{

    [TestFixture()]
    public class TupleTest
    {
        Factory clunk = new Factory();

        [Test()]
        public void emptyPack()
        {
            Tup t = clunk.Tup.pack();
            Assert.AreEqual(0, t.size());
            Assert.AreEqual(0, t.explode().Length);
        }

        [Test()]
        public void singlePack()
        {
            Tup t = clunk.Tup.pack(13);
            Assert.AreEqual(1, t.size());
            Assert.AreEqual(13, t.item(0));
            Assert.AreEqual(new object[] { 13 }, t.explode());
        }

        [Test()]
        public void singleUnpack()
        {
            Tup t = clunk.Tup.pack(13);
          
            object target;
            t.unpack(out target);
        
            Assert.AreEqual(13, target);
            Assert.AreEqual(target, t.item(0));
        }

        [Test()]
        public void multiplePack()
        {
            Tup t = clunk.Tup.pack(2, 4, 6);
            Assert.AreEqual(3, t.size());
            Assert.AreEqual(6, t.item(2));

            t = clunk.Tup.pack(new object[3]{ 1, 3, 5 });
            Assert.AreEqual(3, t.size());
            Assert.AreEqual(5, t.item(2));
        }

        [Test()]
        public void multipleUnPack()
        {
            Tup t = clunk.Tup.pack(2, 4, 6);
            object x, y, z;
            t.unpack(out x, out y, out z);
        
            Assert.AreEqual(2, x);
            Assert.AreEqual(4, y);
            Assert.AreEqual(6, z);
        }
    }
}

