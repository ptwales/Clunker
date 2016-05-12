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
		/// Returns a Maybe that contain's a non-null object.
		/// Will error if null.
		/// </summary>
		/// <param name="boxed">Non-null object to contain.</param>
		public Maybe some(object boxed)
		{
			return new Some(boxed);
		}

		public Maybe none()
		{
			return new None();
		}

		public Applicable onArgs(object obj, string method)
		{
			return new OnArgs(obj, method);
		}

		public Applicable onObject(string method, params object[] args)
		{
			return new OnObject(method, args);
		}
			
	}
}

