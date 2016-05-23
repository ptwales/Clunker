﻿using System;
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
		/// Creates a new instance of an <see cref="Assoc"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="val">Value.</param>
		public Assoc assoc(object key, object val)
		{
			return new Assoc(key, val);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Assoc"/> class,
		/// where the value is the result of op applied to the key.
		/// </summary>
		/// <param name="op">Function to apply to the key to get the value.</param>
		/// <param name="key">Key.</param>
		public Assoc memeo(Func op, object key)
		{
			return new Assoc(key, op.apply(key));
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
		/// Creates a <see cref="Some"/> that contains a non-null object.
		/// Will error if null.
		/// </summary>
		/// <param name="boxed">Non-null object to contain.</param>
		public Maybe some(object boxed)
		{
			return new Some(boxed);
		}

		/// <summary>
		/// Creates an instance of a <see cref="None"/>.
		/// </summary>
		/// <returns>A <see cref="None"/> object.</returns>
		public Maybe none()
		{
			return new None();
		}

		public Func varagFunc(Splat s)
		{
			return new VariadicFunction(s);
		}

		public Func1 unaryFunc(Unary f)
		{
			return new UnaryFunction(f);
		}

		public Pred predicate(Unary f)
		{
			return unaryFunc(f).asPredicate();
		}

		/// <summary>
		/// Creates an instance of an <see cref="OnArgs"/>.
		/// </summary>
		/// <returns>A new <see cref="OnArgs"/> object.</returns>
		/// <param name="obj">Object to call on.</param>
		/// <param name="method">Name of method to call.</param>
		public Func onArgs(object obj, string method)
		{
			return new OnArgs(obj, method);
		}

		/// <summary>
		/// Creates an instance of an <see cref="OnObject"/>.
		/// </summary>
		/// <returns>A new <see cref="Clunker.OnObject"/>.</returns>
		/// <param name="method">Name of method to call</param>
		/// <param name="args">Arguments to call with the method.</param>
		public Func onObject(string method, params object[] args)
		{
			return new OnObject(method, args);
		}

		/// <summary>
		/// Creates a instance of an <see cref="Tuple"/>, containing 
		/// the given elements.
		/// </summary>
		/// <returns>A new <see cref="Clunker.Tuple"/>
		/// <param name="elements">Elements to include in the tuple.</param>
		public Tuple pack(params object[] elements)
		{
			return new Tuple(elements);
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

