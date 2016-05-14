using System;

namespace Clunker
{
    public interface Applicable<Result>
	{		
		/// <summary>
		/// Varag wrapper to <see cref="Clunker.Applicable.applyOnArray"/>
		/// </summary>
		/// <param name="args">Arguments for the function as <c>params</c>
		/// </param>
		Result apply(params object[] args);

		/// <summary>
		/// Applies this function to the array of arguments.
		/// </summary>
		/// <returns>The result of applying this function to args.</returns>
		/// <param name="args">Arguments for the function</param>
		Result applyOnArray(object[] args);
    }
}

