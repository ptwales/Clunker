using NUnit.Framework;

using System;
using System.Collections;

using Clunker;
using Clunker.Collections;

namespace ClunkerTests.Collection
{
    [TestFixture()]
    public class TraversableTest
    {
        [Test(),
         TestCaseSource(typeof(TraversableCaseFactory),
         "emptyTraversables")]
        public void isEmptySourceTest(Traversable emptySequence)
        {
            Assert.IsTrue(emptySequence.isEmpty());
            Assert.IsTrue(emptySequence.maybeHead().isNone());
            Assert.IsTrue(emptySequence.maybeLast().isNone());

            Pred any = new PredFunc(x => true);
            Assert.IsTrue(emptySequence.find(any).isNone());
            Assert.IsTrue(emptySequence.findLast(any).isNone());
        }

        [Test(),
         TestCaseSource(typeof(TraversableCaseFactory),
         "nonEmptyTraversables")]
        public void nonEmptyTest(Traversable sequence)
        {
            Assert.IsFalse(sequence.isEmpty());
            Assert.IsTrue(sequence.maybeHead().isSome());

            Pred any = new PredFunc(x => true);
            Assert.IsTrue(sequence.find(any).isSome());
            Assert.IsTrue(sequence.findLast(any).isSome());
        }

        [Test(),
         TestCaseSource(typeof(TraversableCaseFactory),
         "findTraversables")]
        public void findTest(Traversable sequence)
        {
            Pred isEven = new PredFunc((i) => (int)i % 2 == 0);
            Assert.AreEqual(sequence.find(isEven).getItem(), 2);
            Assert.AreEqual(sequence.findLast(isEven).getItem(), 4);

            Pred isNegative = new PredFunc((i) => (int)i < 0);
            Assert.IsTrue(sequence.find(isNegative).isNone());
            Assert.IsTrue(sequence.findLast(isNegative).isNone());
        }

        [Test(),
         TestCaseSource(typeof(TraversableCaseFactory),
         "sumTraversables")]
        public int sumFoldTest(Traversable sequence, int seed)
        {
            Func2 sum = new BinaryFunction((x, y) => (int)x + (int)y);
            return (int)(sequence.foldLeft(seed, sum));
        }

        [Test(),
         TestCaseSource(typeof(TraversableCaseFactory),
         "sumTraversables")]
        public int sumReduceTest(Traversable sequence, int seed)
        {
            Func2 sum = new BinaryFunction((x, y) => (int)x + (int)y);
            return seed + (int)(sequence.reduceLeft(sum));
        }
    }

    public class TraversableCaseFactory
    {
        private static Factory clunk = new Factory();

        public static IEnumerable emptyTraversables
        {
            get
            {
                yield return new TestCaseData(clunk.List.make());
            }
        }

        public static IEnumerable nonEmptyTraversables
        {
            get
            {
                yield return new TestCaseData(clunk.List.make(1));
            }
        }

        public static IEnumerable findTraversables
        {
            get
            {
                yield return new TestCaseData(clunk.List.make(1, 1, 2, 1, 4));
            }
        }

        public static IEnumerable sumTraversables
        {
            // TODO: Randomly generate this data.
            get
            {
                yield return new TestCaseData(clunk.List.make(1, 2, 4), 3)
                    .Returns(10);
                yield return new TestCaseData(clunk.List.make(1, 2, 3), 0)
                    .Returns(6);
            }
        }
    }
}