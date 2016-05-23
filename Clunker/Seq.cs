﻿using System;

namespace Clunker.Collections
{
	public interface Seq : Monadic<Seq>, Transversable, Showable
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
		Seq tail();

		/// <summary>
		/// Return the sequence without the last element.
		/// </summary>
		Seq init();

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
		Maybe indexWhere(Pred pred);

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
		Maybe lastIndexWhere(Pred pred);

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

		//Seq takeLeft(int n);
		//Seq takeRight(int n);
		//Seq takeWhile(Pred p);
		//Seq dropLeft(int n);
		//Seq dropRight(int n);
		//Seq dropWhile(Pred p);
		//object foldLeft(object z, Func f);
		//object foldRight(object z, Func f);
		//object reduceLeft(Func f);
		//object reduceRight(Func f);

		//Tuple partition(Pred p);

		// Seqs of Seqs should use iterators.
		//Iter scanLeft(object z, Func f);
		//Iter scanRight(object z, Func f);
		//Iter inits();
		//Iter tails();
		//Iter sliding(int size, int step);
		//Iter sliding(int size);
		//Iter grouped(int size);
    }

	public abstract class AbstractSequence : Seq
	{
		// ---------------- Linear -------------------------
		public int size()
		{
			return upperBound() - lowerBound() + 1;
		}

		public object head()
		{
			return item(lowerBound());
		}

		public object last()
		{
			return item(upperBound());
		}

		public bool isEmpty()
		{
			return size() == 0;
		}

		public Maybe maybeHead()
		{
			if (!isEmpty()) {
				return new Some(head());
			} else {
				return new None();
			}
		}

		public Maybe maybeLast() 
		{
			if (!isEmpty()) {
				return new Some(last());
			} else {
				return new None();
			}
		}

		public Maybe indexOf(object val)
		{
			Unary eq = a => a.Equals(val);
			return indexWhere(new UnaryFunction(eq).asPredicate());
		}

		public Maybe lastIndexOf(object val)
		{
			Unary eq = a => a.Equals(val);
			return lastIndexWhere(new UnaryFunction(eq).asPredicate());
		}

		public Maybe find(Pred pred)
		{
			return indexWhere(pred).map(new OnArgs(this, "item"));
		}

		public Maybe findLast(Pred pred)
		{
			return lastIndexWhere(pred).map(new OnArgs(this, "item"));
		}

		protected Maybe findResult(int result, int invalid)
		{
			if (result != invalid) {
				return new Some(result);
			} else {
				return new None();
			}
		}

		public abstract int lowerBound();

		public abstract int upperBound();

		public abstract object item(int index);

		public abstract Seq tail();

		public abstract Seq init();

		public abstract object[] toArray();

		public abstract Maybe indexWhere(Pred pred);

		public abstract Maybe lastIndexWhere(Pred pred);

		public abstract int countWhere(Pred pred);

		// ------------------ Monadic ---------------------

		public abstract Seq map(Func f);
		public abstract Seq flatMap(Func f);
		public abstract Seq filter(Pred p);

		// ------------------ Showable --------------------
	
		public abstract string show();
	}

}
