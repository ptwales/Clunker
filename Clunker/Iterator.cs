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

    public abstract class AbstractIterator: AbstractTraversable, Iterator
	{
		// Methods that must be implemented
		public abstract bool hasNext();
		public abstract object next();
        override public IEnumerator GetEnumerator()
        {
            while (hasNext()) {
                yield return next();
            }
        }
	}

	class CompatIterator: AbstractIterator
	{
        private IEnumerator _iter;
		private bool _hasNext;
        private object _next;

        public CompatIterator(IEnumerator iter)
		{
            _iter = iter;
            next();
		}

		override public bool hasNext() 
		{
			return _hasNext;
		}

		override public object next()
		{
            var result = _next;
            _hasNext = _iter.MoveNext();
            _next = _hasNext ? _iter.Current : null;
            return result;
		}
	}
}

