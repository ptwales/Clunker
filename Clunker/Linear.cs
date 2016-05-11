using System;

namespace Clunker
{
	public interface Linear
	{
		// fundamentals
		int lowerBound();

		int upperBound();

		int size();

		object item(int index);

		// for those car/cdr types
		object head();

		Linear tail();

		Linear init();

		object last();

		Maybe maybeHead();

		Maybe maybeLast();

		// Conversions
		object[] toArray();
		// buildable

		// functional idioms
		Maybe indexWhere(Applicable pred);

		Maybe indexOf(object val);

		Maybe lastIndexWhere(Applicable pred);

		Maybe lastIndexOf(object val);

		Maybe find(Applicable pred);

		Maybe findLast(Applicable pred);

		int countWhere(Applicable pred);
	}

	abstract class AbstractLinear : Linear
	{
		// fundamentals
		public abstract int lowerBound();

		public abstract int upperBound();

		public abstract int size();

		public abstract object item(int index);

		// for those car/cdr types
		public abstract object head();

		public abstract Linear tail();

		public abstract Linear init();

		public abstract object last();

		public abstract Maybe maybeHead();

		public abstract Maybe maybeLast();

		// Conversions
		public abstract object[] toArray();
		// buildable

		// functional idioms
		public abstract Maybe indexWhere(Applicable pred);

		public abstract Maybe indexOf(object val);

		public abstract Maybe lastIndexWhere(Applicable pred);

		public abstract Maybe lastIndexOf(object val);

		public abstract Maybe find(Applicable pred);

		public abstract Maybe findLast(Applicable pred);

		public abstract int countWhere(Applicable pred);
	}
}

