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

		/// <summary>
		/// Assign the elements of the tuple to the targets.
		/// </summary>
		/// <remarks>Caution! overwrites the targets.</remarks>
		/// <param name="targets">Objects to be overwritten with the tuple's
		/// contents.</param>
		public void unpack(object[] targets)
		{
			if (targets.Length == _elements.Length) {
				Array.Copy(_elements, targets, _elements.Length);
			} else {
				string msg = String.Format("Incorrect target count: expected {0}, received {1}.",
					             _elements.Length, targets.Length);
				throw new ArgumentException(msg, "targets");
			}
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

