using NUnit.Framework;
using System;

using Clunker;
using Clunker.Collections;

/*
 * This file is temporary. It should be abstracted later into a "test sequence"
 * class that maintains that all seqs follow certain rules.
 */

namespace ClunkerTests
{
    [TestFixture()]
    public class ListTest
    {
        private static object[] _array = new object[] { 'a', "b", 0 };
        private static int aLower = 0;
        private static int aUpper = _array.Length - 1;
        private static Factory f = new Factory();
        private Seq _list = f.seq(_array);

        [Test()]
        public void itemTest()
        { 
            for (int i = 0; i <= _array.Length - 1; ++i) {
                Assert.AreEqual(_array[i], _list.item(i));
            }
        }

        [Test()]
        public void boundsTest()
        {
            Assert.AreEqual(aLower, _list.lowerBound());
            Assert.AreEqual(aUpper, _list.upperBound());
            Assert.AreEqual(aUpper + 1, _list.size());
        }

        [Test()]
        public void headLastTest()
        {
            Assert.AreEqual(_array[aLower], _list.head());
            Assert.AreEqual(_array[aUpper], _list.last());
        }

        [Test()]
        public void tailTest()
        {
            Seq t = _list.tail();
            Assert.AreEqual(_array[aLower + 1], t.head());
            Assert.AreEqual(_array.Length - 1, t.size());
        }

        [Test()]
        public void initTest()
        {
            Seq i = _list.init();
            Assert.AreEqual(_array[aLower], i.head());
            Assert.AreEqual(_list.head(), i.head());
            Assert.AreEqual(_array.Length - 1, i.size());
        }

        [Test()]
        public void indexWhereTest()
        {
            Pred p = f.predicate(x => x.Equals(_array[0]));
            Assert.AreEqual(0, _list.indexWhere(p).getItem());
        }

        [Test()]
        public void indexOfTest()
        {
            Assert.AreEqual(0, _list.indexOf(_array[0]).getItem());
            Assert.IsTrue(_list.indexOf('b').isNone());
        }

        [Test()]
        public void lastIndexWhereTest()
        {
            Pred p = f.predicate(x => x.Equals(_array[0]));
            Assert.AreEqual(0, _list.lastIndexWhere(p).getItem());
        }

    }
}

