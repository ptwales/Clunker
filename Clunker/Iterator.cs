using System;
using System.Collections.Generic;

namespace Clunker.Collections
{
    public interface Iterator
    {
		bool hasNext();
		object next();
		IEnumerator<object> enumerator();
    }

	public class Enumerator: Iterator
	{
		private IEnumerator<object> _iter;
		private bool _hasNext = false;

		public Enumerator(IEnumerator<object> iter)
		{
			_iter = iter;
		}

		public bool hasNext() 
		{
			return _hasNext;
		}

		public object next()
		{
			_hasNext = _iter.MoveNext();
			return _iter.Current;
		}

		public IEnumerator<object> enumerator()
		{
			return _iter;
		}
	}
}

