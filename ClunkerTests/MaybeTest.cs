using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class MaybeTest
    {
        private Factory f = new Factory();

        [Test()]
        public void maybeSomeConstructor()
        {
            Maybe some = f.maybe(0);
            Assert.IsTrue(some.isSome());
            Assert.AreEqual(0, some.getItem());
        }

        [Test()]
        public void maybeNoneConstructor()
        {
            Maybe none = f.maybe(null);
            Assert.IsTrue(none.isNone());
            Assert.AreEqual(12, none.getOrElse(12));
        }

        [Test()]
        public void someConstructor()
        {
            Maybe some = f.some(1);
            Assert.AreEqual(1, some.getItem());
            try {
                f.some(null);
                Assert.Fail("Didn't raise an exception at all.");
            } catch (ArgumentNullException ane) {
                Assert.Pass("Raised expected exception: " + ane.ToString());
            } catch(Exception e) {
                Assert.Fail("Raised unknown exception: " + e.ToString());
            }
        }
    }
}

