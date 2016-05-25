using System;

namespace Clunker.Collections
{
    public interface Iterable : Transversable
    {
    }

	public abstract class AbstractIterable : AbstractTransversable, Iterable
	{
	}
}

