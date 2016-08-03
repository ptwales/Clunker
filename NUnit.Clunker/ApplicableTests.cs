using NUnit.Framework;
using System;
using Clunker;

namespace ClunkerTests
{

    [TestFixture()]
    public class ApplicableTests
    {
        private static Factory clunk   = new Factory();
        private static FuncN argLength = new VariadicFunction((object[] a) => a.Length);
        private static FuncN plus10    = new VariadicFunction(x => (int)x[0] + 10);
        private static Func1 sqr       = new UnaryFunction(x => (int)x * (int)x);
        private static Pred iseven     = new UnaryFunction(x => (int)x % 2 == 0).asPredicate();
        private static Func2 mul       = new BinaryFunction((x, y) => (int)x * (int)y);
        private static FuncN part      = argLength.asPartial(1, 2, null);


        // ----------------- Variadic ------------------------------------------

        [Test()]
        public void testApplyVariadic()
        {
            Assert.AreEqual(0, argLength.apply());
            Assert.AreEqual(1, argLength.apply('a'));
            Assert.AreEqual(3, argLength.apply(1, 1, 1));
        }

        [Test()]
        public void testPartial()
        {
            Assert.AreEqual(3, part.apply(2),
                "With null field");
            Assert.AreEqual(2, argLength.asPartial(1, 2).apply(),
                "Without null field");
        }

//        [Test()]
//        public void testPartialErrors()
//        {
//            Assert.That(() => part.apply(2, 3).Equals(3),
//                Throws.TypeOf<ArgumentException>);
//        }

        [Test()]
        public void testTupled()
        {
            Func1 packed = argLength.tupled();
            Tup args = clunk.Tup.pack(1, 2, 'a');
            Assert.AreEqual(3, packed.apply(args));
        }

        [Test()]
        public void testAsUnAry()
        {
            Func1 unary = argLength.asUnary();
            Assert.AreEqual(1, unary.apply(12));
        }

        // ----------------- Unary ---------------------------------------------

        [Test()]
        public void testUnary()
        {
            Assert.AreEqual(4, sqr.apply(2));
        }

        [Test()]
        public void testComposed()
        {
            Func1 comp = sqr.compose(plus10.asUnary());
            Func1 andT = plus10.asUnary().andThen(sqr);
            Assert.AreEqual(121, comp.apply(1));
            Assert.AreEqual(121, andT.apply(1));
        }
       
        // TODO: ASDELEGATE

        // ----------------- Binary --------------------------------------------

        [Test()]
        public void testBinary()
        {
            Assert.AreEqual(20, mul.apply(2, 10));
        }

        // TODO: ASDELEGATE

        // ----------------- Predicate -----------------------------------------

        [Test()]
        public void testPredicate()
        {
            Assert.IsTrue(iseven.apply(12));
            Assert.IsFalse(iseven.apply(13));
        }

        // TODO: ASDELEGATE
    }
}

