using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class Factory
	{
		public Factory()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Maybe"/> class.
		/// Maybe will be none if object is null and some otherwise
		/// </summary>
		/// <param name="boxed">Object to contain, may be null.</param>
		public Maybe maybe(object boxed)
		{
			if (boxed != null) {
				return new Some(boxed);
			} else {
				return new None();
			}
		}

		/// <summary>
		/// Creates a <see cref="Clunker.Some"/> that contains a non-null object.
		/// Will error if null.
		/// </summary>
		/// <param name="boxed">Non-null object to contain.</param>
		public Maybe some(object boxed)
		{
			return new Some(boxed);
		}

		/// <summary>
		/// Creates an instance of a <see cref="Clunker.None"/>.
		/// </summary>
		public Maybe none()
		{
			return new None();
		}

		/// <summary>
		/// Creates an instance of an <see cref="Clunker.OnArgs"/>.
		/// </summary>
		/// <returns>A new <see cref="Clunker.OnArgs"/> object.</returns>
		/// <param name="obj">Object to call on.</param>
		/// <param name="method">Name of method to call.</param>
		public Applicable onArgs(object obj, string method)
		{
			return new OnArgs(obj, method);
		}

		/// <summary>
		/// Creates an isntance of an <see cref="Clunker.OnObject"/>.
		/// </summary>
		/// <returns>A new <see cref="Clunker.OnObject"/>.</returns>
		/// <param name="method">Name of method to call</param>
		/// <param name="args">Arguments to call with the method.</param>
		public Applicable onObject(string method, params object[] args)
		{
			return new OnObject(method, args);
		}
			
	}
}

