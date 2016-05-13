using System;
using System.Runtime.InteropServices;

namespace Clunker
{
   
	public interface Maybe : Monadic<Maybe>, Showable
	{
		/// <summary>
		/// Returns <c>true</c> if is <see cref="Clunker.Some"/>,
		/// <c>false</c> otherwise.
		/// </summary>
		/// <returns><c>true</c> if is <see cref="Clunker.Some"/>,
		/// <c>false</c> otherwise.</returns>
		bool isSome();

		/// <summary>
		/// Returns <c>true</c> if is <see cref="Clunker.None"/>,
		/// <c>false</c> otherwise.
		/// </summary>
		/// <returns><c>true</c> if is <see cref="Clunker.None"/>,
		/// <c>false</c> otherwise.</returns>
		bool isNone();

		/// <summary>
		/// Returns contained object this is <see cref="Clunker.Some"/>,
		/// throws an error otherwise.
		/// </summary>
		/// <returns>The contained object or error is thrown.</returns>
		object getItem();

		/// <summary>
		/// Returns contained object this is <see cref="Clunker.Some"/>, 
		/// or <c>other</c> if it is <see cref="Clunker.None"/>.
		/// </summary>
		/// <returns>Contained object if this is <see cref="Clunker.Some"/>,
		/// <c>other</c> if it is <see cref="Clunker.None"/>.</returns>
		/// <param name="other">Other.</param>
		object getOrElse(object other);
	}
		
	class Some : Maybe
	{
		/// <summary>
		/// Single value contained by the Maybe object.
		/// </summary>
		private object _boxed;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Some"/> class
		/// containing non-null object <c>boxed</c>.
		/// </summary>
		/// <param name="boxed">Non null object to contain.</param>
		public Some(object boxed)
		{
			if (boxed != null) {
				_boxed = boxed;
			} else {
				throw new ArgumentNullException("boxed", 
					"Cannot create some of null object, use maybe instead.");
			}
		}

		/// <summary>
		/// <c>true</c>, always.
		/// </summary>
		/// <returns><c>true</c>, always.</returns>
		public bool isSome()
		{
			return true;
		}

		/// <summary>
		/// <c>false</c>, always.
		/// </summary>
		/// <returns><c>false</c>, always.</returns>
		public bool isNone()
		{
			return false;
		}

		/// <summary>
		/// Return the contained object.
		/// </summary>
		/// <returns>The contained object.</returns>
		public object getItem()
		{
			return _boxed;
		}

		/// <summary>
		/// Return the contained object.
		/// </summary>
		/// <returns>The contained object.</returns>
		/// <param name="other">What would be returned if this was a
		/// <see cref="Clunker.None"/>.</param>
		public object getOrElse(object other)
		{
			return _boxed;
		}

		/// <summary>
		/// Return a <see cref="Clunker.Some"/> containing the result
		/// of applying f to the contents of this <see cref="Clunker.Some"/>.
		/// </summary>
		/// <returns><c>Some(f.apply(boxed))</c></returns>
		/// <param name="f">The function to apply</param>
		public Maybe map(Applicable f)
		{
			var result = f.apply(_boxed);
			return new Some(result);
		}

		/// <summary>
		/// Returns the result of applying f to the contained object.
		/// The result must be a <see cref="Clunker.Maybe"/>, or else 
		/// a runtime error will occur.
		/// </summary>
		/// <returns>A <see cref="Clunker.Maybe"/> that is the result
		/// of applying f to the contained object.</returns>
		/// <param name="f">The function to apply.  It must return a 
		/// <see cref="Clunker.Maybe"/></param>
		public Maybe flatMap(Applicable f)
		{
			return (Maybe) f.apply(_boxed);
		}

		/// <summary>
		/// Show this instance.
		/// </summary>
		/// <returns>A string representing this object.</returns>
		public string show()
		{
			return DefShow.showParameters(this, _boxed);
		}
	}
		
	class None : Maybe
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.None"/> class.
		/// </summary>
		public None()
		{
			// nothing to do.    
		}

		/// <summary>
		/// Returns <c>false</c>, always.
		/// </summary>
		/// <returns><c>false</c>, always.</returns>
		public bool isSome()
		{
			return false;
		}

		/// <summary>
		/// <c>true</c>, always.
		/// </summary>
		/// <returns><c>true</c>, always.</returns>
		public bool isNone()
		{
			return true;
		}

		/// <summary>
		/// Throws a <c>NullReferenceException</c>
		/// </summary>
		/// <returns>Nothing, will always throw an exception.</returns>
		public object getItem()
		{
			throw new NullReferenceException("Calling getItem on None object");
		}

		/// <summary>
		/// Returns other, always.
		/// </summary>
		/// <returns>other</returns>
		/// <param name="other">Object to return.</param>
		public object getOrElse(object other)
		{ 
			return other; 
		}

		/// <summary>
		/// Returns a new <see cref="Clunker.None"/>.
		/// </summary>
		/// <param name="f">Function to apply to the contained object if this
		/// was a <see cref="Clunker.Some"/>.</param>
		public Maybe map(Applicable f)
		{
			return new None();
		}

		/// <summary>
		/// Returns a new <see cref="Clunker.None"/>.
		/// </summary>
		/// <param name="f">Function to apply to the contained object if this
		/// was a <see cref="Clunker.Some"/>.</param>
		public Maybe flatMap(Applicable f)
		{
			return new None();
		}

		/// <summary>
		/// Show this instance. Always <c>"None()"</c>.
		/// </summary>
		public string show()
		{
			return "None()";
		}
	}
}
