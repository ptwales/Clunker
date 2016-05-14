using System;

namespace Clunker
{
	public class Tuple : Showable
	{
		private object[] _elements;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Tuple"/> class.
		/// </summary>
		/// <param name="elements">Elements to contain in the tuple.</param>
		public Tuple(params object[] elements)
		{
			_elements = new object[elements.Length];
			Array.Copy(elements, _elements, elements.Length);
		}

		/// <summary>
		/// Return the item at the given index.
		/// </summary>
		/// <param name="index">Index of the desired item.</param>
		public object item(int index)
		{
			return _elements[index];
		}

		/// <summary>
		/// Return the number of items in this tuple.
		/// </summary>
		public int size()
		{
			return _elements.Length;
		}

		/// <summary>
		/// Return the contents of the tuple as an array.
		/// </summary>
		public object[] explode()
		{
			return _elements;
		}

		/*
		 * Bonus points for anyone who can abstract out this pattern.
		 * 
		 * The goal is to use `out` or `ref` with `params`, which is 
		 * forbbiden in C Sharp for good reasons.
		 * 
		 * I tried simplifying by having them all call the same helper
		 * method that accepted an array but you cannot pass an `out`
		 * parameter before assigning it.
		 */

		public void unpack(out object a0)
		{
			if (_elements.Length == 1) {
				a0 = _elements[0];
			} else {
				throw incorrectTargetCount(1);
			}
		}

		public void unpack(out object a0, out object a1)
		{
			if (_elements.Length == 2) {
				a0 = _elements[0];
				a1 = _elements[1];
			} else {
				throw incorrectTargetCount(2);
			}
		}

		public void unpack(out object a0, out object a1, out object a2)
		{
			if (_elements.Length == 3) {
				a0 = _elements[0];
				a1 = _elements[1];
				a2 = _elements[2];
			} else {
				throw incorrectTargetCount(3);
			}
		}

		private Exception incorrectTargetCount(int targetCount)
		{
			string msg = String.Format("Incorrect target count: expected {0}, received {1}.", 
				_elements.Length, targetCount);
			return new ArgumentException(msg);
		}


		/// <summary>
		/// Show this instance as a string.
		/// </summary>
		public string show()
		{
			return DefShow.showBySequence(this, _elements);
		}

	}
}

