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
}

