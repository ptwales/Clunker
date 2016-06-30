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
            Maybe some = clunk.maybe(0);
            Assert.IsTrue(some.isSome());
            Assert.AreEqual(0, some.getItem());
        }

        [Test()]
        public void maybeNoneConstructor()
        {
            Maybe none = clunk.maybe(null);
            Assert.IsTrue(none.isNone());
            Assert.AreEqual(12, none.getOrElse(12));
        }

        [Test()]
        public void someConstructor()
        {
            Maybe some = clunk.some(1);
            Assert.AreEqual(1, some.getItem());
            try {
                clunk.some(null);
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
            Maybe some = clunk.some(1);
            Maybe none = clunk.none();
            Assert.AreEqual("Some(1)", some.show());
            Assert.AreEqual("None()", none.show());
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

