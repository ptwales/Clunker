using System;
using System.Collections;

using Clunker.Factories;

namespace Clunker.Collections
{
    public interface Traversable : IEnumerable
    {
        /// <summary>
        /// Check if the object has no elements.
        /// </summary>
        /// <returns><c>true</c>, if the object is empty <c>false</c>
        ///  otherwise.</returns>
        bool isEmpty();

        /// <summary>
        /// Return the first element of this sequence.
        /// </summary>
        object head();

        /// <summary>
        /// Return the last element in the sequence.
        /// </summary>
        object last();

        /// <summary>
        /// Return a <see cref="Clunker.Some"/> containing the first
        /// element, or <see cref="Clunker.None"/>, if the sequence is
        /// empty.
        /// </summary>
        /// <returns>Maybe the first element.</returns>
        Maybe maybeHead();

        /// <summary>
        /// Return a <see cref="Clunker.Some"/> containing the last
        /// element, or <see cref="Clunker.None"/>, if the sequence is
        /// empty.
        /// </summary>
        /// <returns>Maybe the last element.</returns>
        Maybe maybeLast();

        /// <summary>
        /// Return the value of the first element that satisfies the
        /// predicate as a <see cref="Clunker.Some"/> if found,
        /// <see cref="Clunker.None"/> if no matches.
        /// </summary>
        /// <returns>Maybe the first element that satisfies the predicate
        /// </returns>
        /// <param name="pred">Predicate to check.</param>
        Maybe find(Pred pred);

        /// <summary>
        /// Return the value of the last element that satisfies the
        /// predicate as a <see cref="Clunker.Some"/> if found,
        /// <see cref="Clunker.None"/> if no matches.
        /// </summary>
        /// <returns>Maybe the last element that satisfies the predicate
        /// </returns>
        /// <param name="pred">Predicate to check.</param>
        Maybe findLast(Pred pred);

        /// <summary>
        /// Return the number of elements that satisfy a predicate.
        /// </summary>
        /// <returns>Count of elements that satisfy a predicate.</returns>
        /// <param name="pred">Predicate to check.</param>
        int countWhere(Pred pred);

        object foldLeft(object z, Func2 f);
        //object foldRight(object z, Func2 f);
        object reduceLeft(Func2 f);
        //object reduceRight(Func2 f);
    }

    public abstract class AbstractTraversable : Traversable
    {
        public abstract IEnumerator GetEnumerator();

        public virtual bool isEmpty()
        {
            return !GetEnumerator().MoveNext();
        }

        public virtual object head()
        {
            var iter = GetEnumerator();
            iter.MoveNext();
            return iter.Current;
        }

        public virtual object last()
        {
            var iter = GetEnumerator();
            object result = null;
            while (iter.MoveNext())
            {
                result = iter.Current;
            }
            return result;
        }

        public Maybe maybeHead()
        {
            try
            {
                return new Some(head());
            }
            catch (InvalidOperationException)
            {
                return new None();
            }
        }

        public Maybe maybeLast()
        {
            object l = last();
            if (l != null)
            {
                return new Some(l);
            }
            else
            {
                return new None();
            }
        }

        public virtual Maybe find(Pred pred)
        {
            var iter = GetEnumerator();
            while (iter.MoveNext())
            {
                object x = iter.Current;
                if (pred.apply(x))
                {
                    return new Some(x);
                }
            }
            return new None();
        }

        public virtual Maybe findLast(Pred pred)
        {
            var iter = GetEnumerator();
            object lastFound = null;
            while (iter.MoveNext())
            {
                object x = iter.Current;
                if (pred.apply(x))
                {
                    lastFound = x;
                }
            }
            if (lastFound != null)
            {
                return new Some(lastFound);
            }
            else
            {
                return new None();
            }
        }

        public virtual int countWhere(Pred pred)
        {
            var iter = GetEnumerator();
            int c = 0;
            while (iter.MoveNext())
            {
                if (pred.apply(iter.Current))
                {
                    ++c;
                }
            }
            return c;
        }

        public virtual object foldLeft(object z, Func2 f)
        {
            var iter = GetEnumerator();
            var result = z;
            while (iter.MoveNext())
            {
                result = f.apply(result, iter.Current);
            }
            return result;
        }

        public virtual object reduceLeft(Func2 f)
        {
            var iter = GetEnumerator();
            if (!iter.MoveNext())
            {
                throw new InvalidOperationException(
                    "Cannot reduce on empty sequence");
            }

            var result = iter.Current;
            while (iter.MoveNext())
            {
                result = f.apply(result, iter.Current);
            }
            return result;
        }
    }
}

