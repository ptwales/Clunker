using System;

namespace Clunker
{
	public class Assoc : Showable
	{
		private object _key;
		private object _val;

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Assoc"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="val">Value.</param>
		public Assoc(object key, object val)
		{
			_key = key;
			_val = val;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Clunker.Assoc"/> class,
		/// where the value is the result of op applied to the key.
		/// </summary>
		/// <param name="op">Function to apply to the key to get the value.</param>
		/// <param name="key">Key.</param>
		public Assoc(Applicable op, object key)
		{
			_key = key;
			_val = op.apply(key);
		}

		/// <summary>
		/// Get the key.
		/// </summary>
		public object key()
		{
			return _key;
		}

		/// <summary>
		/// Get the value.
		/// </summary>
		public object value()
		{
			return _val;
		}

		/// <summary>
		/// Show this instance as a string.
		/// </summary>
		public string show()
		{
			return DefShow.show(_key) + " -> " + DefShow.show(_val);
		}
	}
}

