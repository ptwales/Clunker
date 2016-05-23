using System;

namespace Clunker
{
	public interface Transversable
	{
		// Must return an IEnumerable but also something that Linq
		// uses for Select, SelectMany, Count etc.
	}
}

