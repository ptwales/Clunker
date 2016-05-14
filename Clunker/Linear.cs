using System;

namespace Clunker
{
	public interface Linear
	{
		/// <summary>
		/// Return the lowest valid index of the sequence.
		/// </summary>
		/// <returns>Lowest valid index.</returns>
		int lowerBound();

		/// <summary>
		/// Return the highest valid index of the sequence.
		/// </summary>
		/// <returns>Highest valid index</returns>
		int upperBound();

		/// <summary>
		/// Size this instance.
		/// </summary>
		int size();

		/// <summary>
		/// Check if the object has no elements.
		/// </summary>
		/// <returns><c>true</c>, if the object is empty <c>false</c>
		///  otherwise.</returns>
		bool isEmpty();

		/// <summary>
		/// Return the item at the index.
		/// </summary>
		/// <param name="index">Index of the sought item.</param>
		object item(int index);

		/// <summary>
		/// Return the first element of this sequence.
		/// </summary>
		object head();

		/// <summary>
		/// Return the rest of the sequence after the first element.
		/// </summary>
		Linear tail();

		/// <summary>
		/// Return the sequence without the last element.
		/// </summary>
		Linear init();

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
		/// Create an array containing the same elements
		/// </summary>
		/// <returns>This object as an array.</returns>
		object[] toArray();

		/// <summary>
		/// First index who's value satisfies the predicate as a 
		/// <see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the first index that satisfies a predicate.
		/// </returns>
		/// <param name="pred">Predicate to check.</param>
		Maybe indexWhere(Applicable pred);

		/// <summary>
		/// First index who's value equals the given value as a
		/// see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the first index that equals val</returns>
		/// <param name="val">Value sought.</param>
		Maybe indexOf(object val);

		/// <summary>
		/// Last index who's value satisfies the predicate as a 
		/// <see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the last index that satisfies a predicate.
		/// </returns>
		/// <param name="pred">Predicate to check.</param>
		Maybe lastIndexWhere(Applicable pred);

		/// <summary>
		/// Last index who's value equals the given value as a
		/// <see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the last index that equals val</returns>
		/// <param name="val">Value sought.</param>
		Maybe lastIndexOf(object val);

		/// <summary>
		/// Return the value of the first element that satisfies the
		/// predicate as a <see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the first element that satisfies the predicate
		/// </returns>
		/// <param name="pred">Predicate to check.</param>
		Maybe find(Applicable pred);

		/// <summary>
		/// Return the value of the last element that satisfies the
		/// predicate as a <see cref="Clunker.Some"/> if found,
		/// <see cref="Clunker.None"/> if no matches.
		/// </summary>
		/// <returns>Maybe the last element that satisfies the predicate
		/// </returns>
		/// <param name="pred">Predicate to check.</param>
		Maybe findLast(Applicable pred);

		/// <summary>
		/// Return the number of elements that satisfy a predicate.
		/// </summary>
		/// <returns>Count of elements that satisfy a predicate.</returns>
		/// <param name="pred">Predicate to check.</param>
		int countWhere(Applicable pred);
	}
		
}

