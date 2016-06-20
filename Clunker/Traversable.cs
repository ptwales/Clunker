using System;
using System.Collections;

namespace Clunker.Collections
{
	public interface Traversable
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

		//Traversable takeLeft(int n);
		//Traversable takeRight(int n);
		//Traversable takeWhile(Pred p);
		//Traversable dropLeft(int n);
		//Traversable dropRight(int n);
		//Traversable dropWhile(Pred p);
		object foldLeft(object z, Func2 f);
		//object foldRight(object z, Func2 f);
		object reduceLeft(Func2 f);
		//object reduceRight(Func2 f);
	}

	public abstract class AbstractTransversable : Traversable
	{

		public abstract bool isEmpty();
		public abstract object head();
		public abstract object last();
		public abstract Maybe maybeHead();
		public abstract Maybe maybeLast();
		public abstract Maybe find(Pred pred);
		public abstract Maybe findLast(Pred pred);
		public abstract int countWhere(Pred pred);

		//public abstract Traversable takeLeft(int n);
		//public abstract Traversable takeRight(int n);
		//public abstract Traversable takeWhile(Pred p);
		//public abstract Traversable dropLeft(int n);
		//public abstract Traversable dropRight(int n);
		//public abstract Traversable dropWhile(Pred p);
		public abstract object foldLeft(object z, Func2 f);
		//object foldRight(object z, Func2 f);
		public abstract object reduceLeft(Func2 f);
	}
}

