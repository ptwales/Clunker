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

	public abstract class AbstractIterable : Iterable
	{
		public abstract Iterator toIterator();

        public abstract IEnumerator GetEnumerator();

		public bool isEmpty()
		{
			return toIterator().isEmpty();
		}

		public object head()
		{
			return toIterator().head();
		}

		public object last()
		{
			return toIterator().last();
		}

		public Maybe maybeHead()
		{
			return toIterator().maybeHead();
		}

		public Maybe maybeLast()
		{
			return toIterator().maybeLast();
		}

		public Maybe find(Pred pred)
		{
			return toIterator().find(pred);
		}

		public Maybe findLast(Pred pred)
		{
			return toIterator().findLast(pred);
		}

		public int countWhere(Pred pred)
		{
			return toIterator().countWhere(pred);
		}
			
		public object foldLeft(object z, Func2 f)
		{
			return toIterator().foldLeft(z, f);
		}

		//object foldRight(object z, Func2 f);

		public object reduceLeft(Func2 f)
		{
			return toIterator().reduceLeft(f);
		}

		//object reduceRight(Func2 f);
	}
}

