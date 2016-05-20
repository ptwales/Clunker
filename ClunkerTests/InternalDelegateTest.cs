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
        public void identityTest()
        {
            Splat s = a => a[0];
            Func f = factory.internalDelegate(s);
            Assert.AreEqual('a', f.apply('a'));
            Assert.AreEqual(0, f.apply(0));
        }

        [Test()]
        public void operationTest()
        {
            Splat s = a => (string) a[0] + (string) a[1];
            Func f = factory.internalDelegate(s);
            Assert.AreEqual("ab", f.apply("a", "b"));
        }

        [Test()]
        public void booleanFunctionTest()
        {
            Splat s = a => a[0].Equals(a[1]);
            Func f = factory.internalDelegate(s);
            Assert.IsTrue((bool) f.apply(1, 1));
            Assert.IsFalse((bool) f.apply(1, 0));
        }

        [Test()]
        public void predicateTest()
        {
            Splat s = a => a[0].Equals(a[1]);
            Pred p = factory.internalDelegate(s).asPredicate();
            Assert.IsTrue(p.apply('a', 'a'));
            Assert.IsFalse(p.apply(1, 0));
        }
    }
}

