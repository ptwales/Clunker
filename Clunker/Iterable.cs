using System;
using System.Collections.Generic;

namespace Clunker.Collections
{
    public interface Iterable: Traversable
    {
		// move almost everything from Seq here.
		Iterator iterator();

		//Iterable takeLeft(int n);
		//Iterable takeRight(int n);
		//Iterable takeWhile(Pred p);
		//Iterable dropLeft(int n);
		//Iterable dropRight(int n);
		//Iterable dropWhile(Pred p);
	}

	public abstract class AbstractIterable : Iterable
	{
		public abstract Iterator iterator();

		public bool isEmpty()
		{
			return iterator().isEmpty();
		}

		public object head()
		{
			return iterator().head();
		}

		public object last()
		{
			return iterator().last();
		}

		public Maybe maybeHead()
		{
			return iterator().maybeHead();
		}

		public Maybe maybeLast()
		{
			return iterator().maybeLast();
		}

		public Maybe find(Pred pred)
		{
			return iterator().find(pred);
		}

		public Maybe findLast(Pred pred)
		{
			return iterator().findLast(pred);
		}

		public int countWhere(Pred pred)
		{
			return iterator().countWhere(pred);
		}
			
		public object foldLeft(object z, Func2 f)
		{
			return iterator().foldLeft(z, f);
		}

		//object foldRight(object z, Func2 f);

		public object reduceLeft(Func2 f)
		{
			return iterator().reduceLeft(f);
		}

		//object reduceRight(Func2 f);
	}
}

