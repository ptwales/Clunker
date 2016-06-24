using NUnit.Framework;
using System;

using Clunker;

namespace ClunkerTests
{
    using Splat = System.Func<object[], object>;
    using Unary = System.Func<object, object>;

    [TestFixture()]
    public class InternalDelegateTest
    {

        [Test()]
        public void identityTest()
        {
            Splat s = a => a[0];
            FuncN f = new VariadicFunction(s);
            Assert.AreEqual('a', f.apply('a'));
            Assert.AreEqual(0, f.apply(0));
        }

        [Test()]
        public void operationTest()
        {
            Splat s = a => (string)a[0] + (string)a[1];
            FuncN f = new VariadicFunction(s);
            Assert.AreEqual("ab", f.apply("a", "b"));
        }

        [Test()]
        public void booleanFunctionTest()
        {
            Splat s = a => a[0].Equals(a[1]);
            FuncN f = new VariadicFunction(s);
            Assert.IsTrue((bool)f.apply(1, 1));
            Assert.IsFalse((bool)f.apply(1, 0));
        }

        [Test()]
        public void predicateTest()
        {
            Unary f = x => x.Equals('a');
            Pred p = new PredFunc(f);
            Assert.IsTrue(p.apply('a'));
            Assert.IsFalse(p.apply(0));
        }
    }
}

