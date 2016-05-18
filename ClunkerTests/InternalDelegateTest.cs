using NUnit.Framework;
using System;

using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class InternalDelegateTest
    {
        private Factory factory = new Factory();

        [Test()]
        public void testSimple()
        {
            Splat s = a => a[0] == (object) 'a';
            Pred p = factory.internalDelegate(s).asPredicate();
            Assert.IsTrue(p.apply('a'));
            Assert.IsFalse(p.apply(0));
        }
    }
}

