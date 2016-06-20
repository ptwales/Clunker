using System;
using System.Collections.Generic;
using System.Linq;

namespace Clunker.Collections
{
	public interface Seq : Monadic<Seq>, Iterable, Showable
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
		/// Return the item at the index.
		/// </summary>
		/// <param name="index">Index of the sought item.</param>
		object item(int index);

		/// <summary>
		/// Create an array containing the same elements
		/// </summary>
		/// <returns>This object as an array.</returns>
		object[] toArray();

		/// <summary>
		/// Return the rest of the sequence after the first element.
		/// </summary>
		Seq tail();

		/// <summary>
		/// Return the sequence without the last element.
		/// </summary>
		Seq init();

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

	public abstract class AbstractSequence : AbstractIterable, Seq
	{
		// ---------------- Linear -------------------------
		public int size()
		{
			return upperBound() - lowerBound() + 1;
		}

		override public object head()
		{
			return item(lowerBound());
		}

		override public object last()
		{
			return item(upperBound());
		}

		override public bool isEmpty()
		{
			return size() == 0;
		}

		override public Maybe maybeHead()
		{
			if (!isEmpty()) {
				return new Some(head());
			} else {
				return new None();
			}
		}

		override public Maybe maybeLast()
		{
			if (!isEmpty()) {
				return new Some(last());
			} else {
				return new None();
			}
		}

		public Maybe indexOf(object val)
		{
			Predicate<object> eq = a => a.Equals(val);
			return indexWhere(new PredFunc(eq));
		}

		public Maybe lastIndexOf(object val)
		{
			Predicate<object> eq = a => a.Equals(val);
			return lastIndexWhere(new PredFunc(eq));
		}

		override public Maybe find(Pred pred)
		{
			return indexWhere(pred).map(new OnArgs(this, "item").asUnary());
		}

		override public Maybe findLast(Pred pred)
		{
			return lastIndexWhere(pred).map(new OnArgs(this, "item").asUnary());
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

		override public abstract int countWhere(Pred pred);

		override public abstract object foldLeft(object x, Func2 acc);

		override public object reduceLeft(Func2 acc)
		{
			return tail().foldLeft(head(), acc);
		}

		// ------------------ Monadic ---------------------

		public abstract Seq map(Func1 f);

		public abstract Seq flatMap(Func1 f);

		public abstract Seq filter(Pred p);

		// ------------------ Showable --------------------
	
		public abstract string show();
	}

}

