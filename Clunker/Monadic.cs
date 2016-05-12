using System;

namespace Clunker
{
	public interface Monadic
	{
		/// <summary>
		/// Return a new monad where all elements are the results
		/// of applying f to the elements of this monad.
		/// </summary>
		/// <param name="f">Function to apply to all elements</param>
		Monadic map(Applicable f);

		/// <summary>
		/// Return a new monad where all elements are the elements of 
		/// the resulting monads when applying f to the elements of 
		/// this monad.
		/// </summary>
		/// <param name="f">Function that must return a monad.</param>
		Monadic flatMap(Applicable f);
	}
}

