using System;

namespace Clunker
{
	public interface Pred : Applicable<object, bool>
	{
		Func1 asUnary();
	}
}

