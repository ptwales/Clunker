using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Clunker.Collections
{
	using SysList = System.Collections.Generic.List<object>;

	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class List : AbstractSequence
	{
		private SysList _list;

		public List(IEnumerable<object> sequence)
		{
			_list = new SysList(sequence);
		}

		// --------------- Iterable ----------------------

		public override Iterator toIterator()
		{
			return new Enumerator(_list.GetEnumerator());
		}

		// --------------- Seq ---------------------------

		public override int lowerBound()
		{
			return 0;
		}

		public override int upperBound()
		{
			return _list.Count - 1;
		}

		public override object item(int index)
		{
			return _list[index];
		}

		public override Seq tail()
		{
			return new List(_list.GetRange(1, upperBound()));
		}

		public override Seq init()
		{
			return new List(_list.GetRange(0, upperBound()));
		}

		public override object[] toArray()
		{
			return _list.ToArray();
		}

		// ---------------- Monadic ----------------------

		public override Seq map(Func1 f)
		{
			return new List(_list.Select(f.asDelegate()));
		}

		public override Seq flatMap(Func1 f)
		{
			return new List(_list.SelectMany(x => (IEnumerable<object>)f.apply(x)));
		}

		public override Seq filter(Pred p)
		{
			return new List(_list.Where(x => p.apply(x)));
		}

		// ---------------- Showable ---------------------

		public override string show()
		{
			return DefShow.showBySequence(this, _list);
		}
	}
}

