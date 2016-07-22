using System;
using System.Collections;

namespace Clunker.Collections
{
    public interface Iterable: Traversable
    {
		// move almost everything from Seq here.
		Iterator toIterator();

		//Iterable takeLeft(int n);
		//Iterable takeRight(int n);
		//Iterable takeWhile(Pred p);
		//Iterable dropLeft(int n);
		//Iterable dropRight(int n);
		//Iterable dropWhile(Pred p);
	}

	public abstract class AbstractIterable : AbstractTraversable, Iterable
	{
		public abstract Iterator toIterator();
	}
}

