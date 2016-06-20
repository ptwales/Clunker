using System;
using System.Collections.Generic;
using System.Linq;

namespace Clunker.Collections
{
    public interface Iterator: Traversable
    {
		bool hasNext();
		object next();
    }

	public abstract class AbstractIterator: Iterator
	{
		// Methods that must be implemented
		public abstract bool hasNext();
		public abstract object next();

		public bool isEmpty()
		{
			return hasNext();
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
		private IEnumerator<object> _iter;
		private bool _hasNext = false;

		public Enumerator(IEnumerator<object> iter)
		{
			_iter = iter;
		}

		override public bool hasNext() 
		{
			return _hasNext;
		}

		override public object next()
		{
			_hasNext = _iter.MoveNext();
			return _iter.Current;
		}
	}
}

