using System;

namespace Clunker
{
	public delegate object Accum(object x,object y);

	public interface Func2
	{
		object apply(object x, object y);
		//Func1 tupled();
	}

	class BinaryFunction : Func2
	{
		Accum _a;

		public BinaryFunction(Accum a)
		{
			_a = a;
		}

		public object apply(object x, object y)
		{
			return _a(x, y);
		}
	}
}



