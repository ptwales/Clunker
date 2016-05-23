using System;
using System.Runtime.InteropServices;

namespace Clunker
{
	public interface Applicable<in Args, out Result>
	{
		Result apply(Args args);
	}
}

