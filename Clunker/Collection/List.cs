using System;
using System.Collections.Generic;
using System.Linq;

using Clunker.Factories;

namespace Clunker.Collections
{
    using SysList = System.Collections.Generic.List<object>;

	public class List : AbstractSequence
	{
		private SysList _list;

		public List(IEnumerable<object> sequence)
		{
			_list = new SysList(sequence);
		}

        // --------------- Traversable -------------------

        public override Maybe find(Pred pred)
        {
            return MaybeFactory.maybe(_list.Find((Predicate<object>)pred.asLambda()));
        }

		// --------------- Iterable ----------------------

		public override Iterator toIterator()
		{
            return new CompatIterator(GetEnumerator());
		}

        public override System.Collections.IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
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
			return new List(_list.Select((Func<object, object>)f.asLambda()));
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

