using System;
using System.Collections;
using System.Linq;

namespace Clunker.Collections
{
    public interface Iterator: Traversable
    {
		/// <summary>
		/// Check if there iterator has another value.
		/// </summary>
		/// <returns><c>true</c>, if there is another value <c>false</c> otherwise.</returns>
		bool hasNext();

		/// <summary>
		/// Move the iterator to the next object and return that object.
		/// </summary>
		/// <returns>The next object.</returns>
		object next();
    }

	public abstract class AbstractIterator: Iterator
	{
		// Methods that must be implemented
		public abstract bool hasNext();
		public abstract object next();
        public abstract IEnumerator GetEnumerator();

		public bool isEmpty()
		{
			return !hasNext();
		}

		public object head()
		{
			return next();
		}

		public object last()
		{
			object result = null;
			while (hasNext()) {
				result = next();
			}
			return result;
		}

		public Maybe maybeHead()
		{
			try {
				return new Some(head());
			} catch {
				return new None();
			}
		}

		public Maybe maybeLast()
		{
			try {
				return new Some(last());
			} catch {
				return new None();
			}
		}

		public Maybe find(Pred pred)
		{
			while (hasNext()) {
				object x = next();
				if (pred.apply(x)) {
					return new Some(x);
				}
			}
			return new None();
		}

		public Maybe findLast(Pred pred)
		{
			object lastFound = null;
			while (hasNext()) {
				object x = next();
				if (pred.apply(x)) {
					lastFound = x;
				}
			}
			if (lastFound != null) {
				return new Some(lastFound);
			} else {
				return new None();
			}
		}

		public int countWhere(Pred pred)
		{
			int c = 0;
			while (hasNext()) {
				if (pred.apply(next())) {
					++c;
				}
			}
			return c;
		}

		public object foldLeft(object z, Func2 f)
		{
			var result = z;
			while (hasNext()) {
				result = f.apply(result, next());
			}
			return result;
		}

		public object reduceLeft(Func2 f)
		{
			return foldLeft(head(), f);
		}
	}

	class Enumerator: AbstractIterator
	{
		private IEnumerator _iter;
		private object _next;
		private bool _hasNext;

		public Enumerator(IEnumerator iter)
		{
			_iter = iter;
			next();
		}

        override public IEnumerator GetEnumerator()
        {
            return _iter;
        }

		override public bool hasNext() 
		{
			return _hasNext;
		}

		override public object next()
		{
			object current = _next;
			_hasNext = _iter.MoveNext();
			_next = _hasNext ? _iter.Current : null;
			return current;
		}
	}
}

