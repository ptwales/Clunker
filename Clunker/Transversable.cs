using System;
using System.Collections;

namespace Clunker.Collections
{
	public interface Transversable // : IEnumerable
	{
		// Must return an IEnumerable but also something that Linq
		// uses for Select, SelectMany, Count etc.
	}

	public abstract class AbstractTransversable : Transversable
	{
	}
}

