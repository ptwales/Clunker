using System;
using System.Runtime.InteropServices;

using Clunker.Factories;

namespace Clunker
{
	/// <summary>
	/// Clunker uses immutable classes that require dependency injection.  Since
    /// COM doesn't allow constructors with arguments, all objects are created
    /// by an instance of the factory class.
	/// </summary>
	public class Factory
	{
        public readonly MaybeFactory Maybe = new MaybeFactory();
        public readonly AssocFactory Assoc = new AssocFactory();
        public readonly TupFactory Tup = new TupFactory();

		/// <summary>
		/// Creates an instance of an <see cref="OnArgs"/>.
		/// </summary>
		/// <returns>A new <see cref="OnArgs"/> object.</returns>
		/// <param name="obj">Object to call on.</param>
		/// <param name="method">Name of method to call.</param>
		public FuncN onArgs(object obj, string method)
		{
			return new OnArgs(obj, method);
		}

		/// <summary>
		/// Creates an instance of an <see cref="OnObject"/>.
		/// </summary>
		/// <returns>A new <see cref="Clunker.OnObject"/>.</returns>
		/// <param name="method">Name of method to call</param>
		/// <param name="args">Arguments to call with the method.</param>
		public Func1 onObject(string method, params object[] args)
		{
			return new OnObject(method, args);
		}

		/// <summary>
		/// Creates a Sequence (<see cref="Seq"/>) containing the given elements.
		/// </summary>
		/// <returns>A new Seq</returns>
		/// <param name="elements">Elements to be contained in the new Sequence.</param>
		public Collections.Seq seq(params object[] elements)
		{
			return new Collections.List(elements);
		}
	}
}

