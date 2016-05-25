using System;

namespace Clunker.Collections
{
	// I don't know if I'm going to end up using this yet...

    public interface Iterator
    {
		bool hasNext();
		object next();
    }

	abstract class AbstractIterator : Iterator 
	{
		public abstract bool hasNext();
		public abstract object next();
	}
}

