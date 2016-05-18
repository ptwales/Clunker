using NUnit.Framework;
using System;

using Clunker;
using Clunker.Collections;

namespace ClunkerTests
{
    [TestFixture()]
    public class ListTest
    {
        private static Factory f = new Factory();
        private Seq l = f.createList('a', "b", 0);

        [Test()]
        public void itemTest()
        {
            Assert.AreEqual('a', l.item(0));
            Assert.AreEqual("b", l.item(1));
            Assert.AreEqual(0, l.item(2));
        }

        [Test()]
        public void boundsTest()
        {
            Assert.AreEqual(0, l.lowerBound());
            Assert.AreEqual(2, l.upperBound());
            Assert.AreEqual(3, l.size());
        }

        [Test()]
        public void headLastTest()
        {
            Assert.AreEqual('a', l.head());
            Assert.AreEqual(0, l.last());
        }

        [Test()]
        public void tailTest()
        {
            Seq t = l.tail();
            Assert.AreEqual("b", t.head());
            Assert.AreEqual(2, t.size());
        }

        [Test()]
        public void initTest()
        {
            Seq i = l.init();
            Assert.AreEqual('a', i.head());
            Assert.AreEqual(2, i.size());
        }

        [Test()]
        public void indexOfTest()
        {
            Assert.AreEqual(0, l.indexOf('a'));
        }

    }
}

