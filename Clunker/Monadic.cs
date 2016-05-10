using System;

namespace Clunker
{
	public interface Monadic
	{
		Monadic map(Applicable f);
		Monadic flatMap(Applicable f);
	}
}

