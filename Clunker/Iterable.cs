using System;

namespace Clunker.Collections
{
    public interface Iterable : Traversable
    {
		// move almost everything from Seq here.
		Iterator iterator();


	}

	public abstract class AbstractIterable : AbstractTransversable, Iterable
	{
		public abstract Iterator iterator();
	}
}

