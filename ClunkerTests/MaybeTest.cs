using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{
    [TestFixture()]
    public class MaybeTest
    {
        private Factory clunk = new Factory();

        [Test()]
        public void maybeSomeConstructor()
        {
            Maybe some = clunk.Maybe.maybe(0);
            Assert.IsTrue(some.isSome());
            Assert.AreEqual(0, some.getItem());
        }

        [Test()]
        public void maybeNoneConstructor()
        {
            Maybe none = clunk.Maybe.maybe(null);
            Assert.IsTrue(none.isNone());
            Assert.AreEqual(12, none.getOrElse(12));
        }

        [Test()]
        public void someConstructor()
        {
            Maybe some = clunk.Maybe.some(1);
            Assert.AreEqual(1, some.getItem());
            try {
                clunk.Maybe.some(null);
                Assert.Fail("Didn't raise an exception at all.");
            } catch (ArgumentNullException ane) {
                Assert.Pass("Raised expected exception: " + ane.ToString());
            } catch (Exception e) {
                Assert.Fail("Raised unknown exception: " + e.ToString());
            }
        }
        
        [Test()]
        public void showingMaybe()
        {
            Maybe some = clunk.Maybe.some(1);
            Maybe none = clunk.Maybe.none();
            Assert.AreEqual("Clunker.Some(1)", some.show());
            Assert.AreEqual("Clunker.None()", none.show());
        }

        //[Test()]
        //public void attemptConstructor()
        //{
        //    Func f = ???
        //    Delay willPass = f.delay(???);
        //    Maybe passed = f.Attempt(willPass);
        //    Assert.IsTrue(passed.isSome());
        //    Delay willFail = f.delay(???);
        //    Maybe failed = f.Attempt(willFail);
        //    Assert.IsNone(failed.isNone);
        //}

    }
}

