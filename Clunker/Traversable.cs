using System;
using System.Collections;

namespace Clunker
{
    public interface Traversable : IEnumerable
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

		object foldLeft(object z, Func2 f);
		//object foldRight(object z, Func2 f);
		object reduceLeft(Func2 f);
		//object reduceRight(Func2 f);
    }
}

