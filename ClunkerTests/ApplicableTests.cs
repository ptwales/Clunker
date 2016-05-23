using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class ApplicableTests
    {
        private static Factory clunk = new Factory();
        private static Applicable<object[], object> app = clunk.varagFunc(
                                    a => a[0].Equals(a[1]));
        private static Func func = (Func) app;
        private static Func1 func1 = func.asUnary();
        //private static Func2 func2 = func.asBinary();
        private static Pred pred = func1.asPredicate();


        [Test()]
        public void testApplyVariadic()
        {
            Assert.IsTrue((bool)func.apply(1, 1));
            Assert.IsFalse((bool)func.apply(0, 1));
        }

    }
}

